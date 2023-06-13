using AutoMapper;
using ManagementAPI.Context;
using ManagementAPI.Models;
using ManagementAPI.Models.Dto.AreaDto;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ManagementAPI.Services.AreaService
{
    public class AreaService : IAreaService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AreaService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);

        public async Task<object> AddArea(AddAreaDto newArea)
        {
            try
            {
                var area = _mapper.Map<Area>(newArea);

                area.CreatedAt = DateTime.Now;
                area.Status = "Ativo";

                _context.Area.Add(area);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public async Task<object> GetAllArea()
        {
            try
            {
                var dbArea = await _context.Area
                    .Include(c => c.Process)
                    .ToListAsync();

                if (dbArea == null)
                    return false;

                return dbArea;
            }
            catch (Exception ex)
            {
                return ex.Message;
            } 
        }

        public async Task<object> GetAreaById(int id)
        {
            try
            {
                var dbArea = await _context.Area
                    .Include(c => c.Process)
                    .FirstOrDefaultAsync(c => c.AreaId == id);

                if(dbArea == null)
                    return false;

                return dbArea;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> UpdateArea(UpdateAreaDto updatedArea)
        {
            try
            {
                var Area = await _context.Area
                    .FirstOrDefaultAsync(c => c.AreaId == updatedArea.AreaId);

                if (Area is null)
                    return false;

                Area.Name = string.IsNullOrEmpty(updatedArea.Name) ? Area.Name : updatedArea.Name;
                Area.Responsible = string.IsNullOrEmpty(updatedArea.Responsible) ? Area.Responsible : updatedArea.Responsible;
                Area.Description = string.IsNullOrEmpty(updatedArea.Description) ? Area.Description : updatedArea.Description;
                Area.Tools = string.IsNullOrEmpty(updatedArea.Tools) ? Area.Tools : updatedArea.Tools;
                Area.Technologies = string.IsNullOrEmpty(updatedArea.Technologies) ? Area.Technologies : updatedArea.Technologies;
                Area.Status = updatedArea.Status;
                Area.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return _mapper.Map<GetAreaDto>(Area);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> DeleteArea(int id)
        {
            try
            {
                var Area = await _context.Area
                    .FirstOrDefaultAsync(c => c.AreaId == id);

                if (Area == null)
                    return false;

                _context.Area.Remove(Area);

                await _context.SaveChangesAsync();

            }
            catch
            {
                return false;
            }

            return true;
        }

        //    public async Task AddProcessArea(AreaAddDto newProcessArea)
        //    {
        //        var response = new ServiceResponse<GetAreaDto>();
        //        try
        //        {
        //            var Area = await _context.Area
        //                .FirstOrDefaultAsync(c => c.Id == newProcessArea.AreaId
        //                && c.User!.Id == GetUserId());

        //            if (Area is null)
        //            {
        //                response.Success = false;
        //                response.Message = "Area not found.";

        //                return response;
        //            }

        //            var process = await _context.Process
        //                .FirstOrDefaultAsync(s => s.Id == newProcessArea.ProcessId);

        //            if (process is null)
        //            {
        //                response.Success = false;
        //                response.Message = "Process not found.";

        //                return response;
        //            }

        //            Area.Process!.Add(process);
        //            await _context.SaveChangesAsync();
        //            response.Data = _mapper.Map<GetAreaDto>(Area);
        //        }
        //        catch (Exception ex)
        //        {
        //            response.Success = false;
        //            response.Message = ex.Message;
        //        }

        //        return response;
        //    }
        }
    }
