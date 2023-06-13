using AutoMapper;
using ManagementAPI.Context;
using ManagementAPI.Models.Dto.SubprocessDto;
using Microsoft.EntityFrameworkCore;

namespace ManagementAPI.Services.FlowService
{
    public class FlowService : IFlowService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FlowService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        public async Task<object> GetAllAsync(int id)
        {
            try
            {
                var dbFlow = await _context.Area
                    .Include(c => c.Process!)
                    .ThenInclude(c => c.Subprocess)
                    .Where(c => c.AreaId == id)
                    .ToListAsync();

                if (dbFlow == null)
                    return false;

                return dbFlow;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> GetAreaAsync(int id)
        {
            try
            {
                var dbFlow = await _context.Area
                    .Include(c => c.Process)
                    .Where(c => c.AreaId == id)
                    .ToListAsync();

                if (dbFlow == null)
                    return false;

                return dbFlow;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> GetProcAsync(int id)
        {
            try
            {
                //var dbFlow = await _context.Process
                //    .Include(c => c.Subprocess)
                //    .Where(c => c.ProcessId == id)
                //    .ToListAsync();

                var dbFlow = await _context.Process
                    .Where(c => c.AreaID == id)
                    .ToListAsync();

                if (dbFlow == null)
                    return false;

                return dbFlow;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<object> GetSubAsync(int id)
        {
            try
            {
                var dbSubprocess = await _context.Subprocess
                    .Where(c => c.SubprocessId == id)
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

    }
}
