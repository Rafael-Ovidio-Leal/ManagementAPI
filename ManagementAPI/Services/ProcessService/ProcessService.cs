using AutoMapper;
using ManagementAPI.Context;
using ManagementAPI.Models;
using ManagementAPI.Models.Dto.ProcessDto;
using Microsoft.EntityFrameworkCore;

namespace ManagementAPI.Services.ProcessService
{
    public class ProcessService : IProcessService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProcessService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<object> AddProcess(AddProcessDto newProcess)
        {
            try
            {
                var dbProcess = _mapper.Map<Process>(newProcess);

                dbProcess.Area = await _context.Area
                    .FirstOrDefaultAsync(u => u.AreaId == newProcess.AreaId && u.Status == "Ativo");

                dbProcess.CreatedAt = DateTime.Now;
                dbProcess.Status = "Ativo";

                if (dbProcess == null)
                    return false;

                _context.Process.Add(dbProcess);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> GetAllProcess()
        {
            try
            {
                var dbProcess = await _context.Process
                .Include(c => c.Area)
                .ToListAsync();

                if (dbProcess == null)
                    return false;

                return dbProcess;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> GetProcessById(int id)
        {
            try
            {
                var dbProcess = await _context.Process
                .Include(c => c.Area)
                .FirstOrDefaultAsync(c => c.ProcessId == id);

                if (dbProcess == null)
                    return false;

                return dbProcess;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            
        }

        public async Task<object> UpdateProcess(UpdateProcessDto updatedProcess)
        {
            try
            {
                var dbProcess = await _context.Process
                    .FirstOrDefaultAsync(c => c.ProcessId == updatedProcess.ProcessId);

                if(dbProcess == null)
                    return false;

                dbProcess.AreaID = updatedProcess.AreaId == null ? dbProcess.AreaID : updatedProcess.AreaId;
                dbProcess.Name = string.IsNullOrEmpty(updatedProcess.Name) ? dbProcess.Name : updatedProcess.Name;
                dbProcess.Responsible = string.IsNullOrEmpty(updatedProcess.Responsible) ? dbProcess.Responsible : updatedProcess.Responsible;
                dbProcess.Description = string.IsNullOrEmpty(updatedProcess.Description) ? dbProcess.Description : updatedProcess.Description;
                dbProcess.Tools = string.IsNullOrEmpty(updatedProcess.Tools) ? dbProcess.Tools : updatedProcess.Tools;
                dbProcess.Technologies = string.IsNullOrEmpty(updatedProcess.Technologies) ? dbProcess.Technologies : updatedProcess.Technologies;
                dbProcess.Status = updatedProcess.Status;
                dbProcess.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return _mapper.Map<GetProcessDto>(dbProcess);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> DeleteProcess(int id)
        {
            try
            {
                var dbProcess = await _context.Process
                    .FirstOrDefaultAsync(c => c.ProcessId == id);

                if (dbProcess == null)
                    return false;

                _context.Process.Remove(dbProcess);

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
