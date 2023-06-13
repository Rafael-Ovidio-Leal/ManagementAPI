using ManagementAPI.Models.Dto.ProcessDto;
using ManagementAPI.Services.ProcessService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var resp = await _processService.GetAllProcess();

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to get All Process" });
                }

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingle(int id)
        {
            try
            {
                var resp = await _processService.GetProcessById(id);

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to get Process" });
                }

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProcess(AddProcessDto newProcess)
        {
            try
            {
                var resp = await _processService.AddProcess(newProcess);

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to register new Process" });
                }

                return Ok(new
                {
                    Status = 200,
                    Data = resp
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateProcess(UpdateProcessDto updatedProcess)
        {
            try
            {
                var resp = await _processService.UpdateProcess(updatedProcess);
                if (resp is false)
                {
                    return NotFound(new { Message = "Process not found" });
                }

                return Ok(new
                {
                    Status = 200,
                    Message = "Process Update!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProcess(int id)
        {
            try
            {
                var resp = await _processService.DeleteProcess(id);
                if (resp is false)
                {
                    return NotFound(new { Message = "Process not found" });
                }

                return Ok(new
                {
                    Status = 200,
                    Message = "Process Delete!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

        }

    }
}
