using ManagementAPI.Models.Dto.AreaDto;
using ManagementAPI.Services.FlowService;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers
{
    public class FlowController : ControllerBase
    {

        private readonly IFlowService _flowService;

        public FlowController(IFlowService flowService)
        {
            _flowService = flowService;
        }

        [HttpGet("flow/{id}")]
        public async Task<ActionResult> Getall(int id)
        {
            try
            {
                var resp = await _flowService.GetAllAsync(id);

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to get flow" });
                }

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("area/{id}")]
        public async Task<ActionResult> GetAllArea(int id)
        {
            try
            {
                var resp = await _flowService.GetAreaAsync(id);

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to get flow" });
                }

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("proc/{id}")]
        public async Task<ActionResult> GetAllProc(int id)
        {
            try
            {
                var resp = await _flowService.GetProcAsync(id);

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to get flow" });
                }

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("sub/{id}")]
        public async Task<ActionResult> GetSingleSub(int id)
        {
            try
            {
                var resp = await _flowService.GetSubAsync(id);

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to get flow" });
                }

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}

