using AutoMapper;
using ManagementAPI.Context;
using ManagementAPI.Models.Dto.SubprocessDto;
using ManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace ManagementAPI.Services.SubprocessService
{
    public class SubprocessService : ISubprocessService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public SubprocessService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<object> AddSubprocess(AddSubprocessDto newSubprocess)
        {
            try
            {
                var subprocess = _mapper.Map<Subprocess>(newSubprocess);

                if (newSubprocess.ProcessId != 0)
                {
                    subprocess.Process = await _context.Process
                        .FirstOrDefaultAsync(u => u.ProcessId == newSubprocess.ProcessId && u.Status == "Ativo");

                    if (subprocess.Process == null)
                        return false;
                                    
                }
                else
                {
                    subprocess.FatherId = newSubprocess.FatherId;

                    if (subprocess.FatherId == null)
                        return false;
                }

                subprocess.CreatedAt = DateTime.Now;
                subprocess.Status = "Ativo";

                await _context.Subprocess.AddAsync(subprocess);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> GetAllSubprocess()
        {
            try
            {
                var dbSubprocess = await _context.Subprocess
                    .Include(u => u.Process)
                    .ThenInclude(c => c.Subprocess.Where(c => c.SubprocessId == c.FatherId))
                    .ToListAsync();

                if (dbSubprocess == null)
                    return false;

                return dbSubprocess;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> GetSubprocessById(int id)
        {
            try
            {
                var dbSubprocess = await _context.Subprocess
                    .Include(u => u.Process)
                    .FirstOrDefaultAsync(c => c.SubprocessId == id);

                if (dbSubprocess == null)
                    return false;


                return dbSubprocess;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> UpdateSubprocess(UpdateSubprocessDto updatedSubprocess)
        {
            try
            {
                var Subprocess = await _context.Subprocess
                    .FirstOrDefaultAsync(c => c.SubprocessId == updatedSubprocess.SubprocessId);

                if (Subprocess == null)
                    return false;
                
                Subprocess.Name = string.IsNullOrEmpty(updatedSubprocess.Name) ? Subprocess.Name : updatedSubprocess.Name;
                Subprocess.Responsible = string.IsNullOrEmpty(updatedSubprocess.Responsible) ? Subprocess.Responsible : updatedSubprocess.Responsible;
                Subprocess.Description = string.IsNullOrEmpty(updatedSubprocess.Description) ? Subprocess.Description : updatedSubprocess.Description;
                Subprocess.Tools = string.IsNullOrEmpty(updatedSubprocess.Tools) ? Subprocess.Tools : updatedSubprocess.Tools;
                Subprocess.Technologies = string.IsNullOrEmpty(updatedSubprocess.Technologies) ? Subprocess.Technologies : updatedSubprocess.Technologies;
                Subprocess.Status = updatedSubprocess.Status;
                Subprocess.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return _mapper.Map<GetSubprocessDto>(Subprocess);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> DeleteSubprocess(int id)
        {
            try
            {
                var Subprocess = await _context.Subprocess
                    .FirstOrDefaultAsync(c => c.SubprocessId == id);

                if (Subprocess == null)
                    return false;

                _context.Subprocess.Remove(Subprocess);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return true;
        }
    }
}
