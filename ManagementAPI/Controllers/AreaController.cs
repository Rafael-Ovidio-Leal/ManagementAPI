using ManagementAPI.Models.Dto.AreaDto;
using ManagementAPI.Services.AreaService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ManagementAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {

        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var resp = await _areaService.GetAllArea();

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to get All Area" });
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
                var resp = await _areaService.GetAreaById(id);

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to get Area" });
                }

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddArea(AddAreaDto newArea)
        {
            try
            {
                var resp = await _areaService.AddArea(newArea);

                if (resp is false)
                {
                    return BadRequest(new { Message = "Error to register new Area" });
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
        public async Task<ActionResult> UpdateArea(UpdateAreaDto updatedArea)
        {
            try
            {
                var resp = await _areaService.UpdateArea(updatedArea);
                if (resp is false)
                {
                    return NotFound(new { Message = "Area not found" });
                }

                return Ok(new
                {
                    Status = 200,
                    Message = "Area Update!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArea(int id)
        {
            try
            {
                var resp = await _areaService.DeleteArea(id);
                if (resp is false)
                {
                    return NotFound(new { Message = "Area not found" });
                }

                return Ok(new
                {
                    Status = 200,
                    Message = "Area Delete!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
            
        }
    }
}
