using ManagementAPI.Models.Dto.SubprocessDto;
using ManagementAPI.Services.SubprocessService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubprocessController : ControllerBase
    {
        private readonly ISubprocessService _subprocessService;

        public SubprocessController(ISubprocessService subprocessService)
        {
            _subprocessService = subprocessService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var resp = await _subprocessService.GetAllSubprocess();

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
                var resp = await _subprocessService.GetSubprocessById(id);

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
        public async Task<ActionResult> AddSubprocess(AddSubprocessDto newSubprocess)
        {
            try
            {
                var resp = await _subprocessService.AddSubprocess(newSubprocess);

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to register new Subprocess" });
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
        public async Task<ActionResult> UpdateSubprocess(UpdateSubprocessDto updatedSubprocess)
        {
            try
            {
                var resp = await _subprocessService.UpdateSubprocess(updatedSubprocess);
                if (resp is false)
                {
                    return NotFound(new { Message = "Process not found" });
                }

                return Ok(new
                {
                    Status = 200,
                    Message = "Subprocess Update!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubprocess(int id)
        {
            try
            {
                var resp = await _subprocessService.DeleteSubprocess(id);
                if (resp is false)
                {
                    return NotFound(new { Message = "Process not found" });
                }

                return Ok(new
                {
                    Status = 200,
                    Message = "Subprocess Delete!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }


    }
}
