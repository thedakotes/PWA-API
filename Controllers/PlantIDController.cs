using API.DataTransferObjects;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantIDController : ControllerBase
    {
        IPlantIDService _plantIDService;
        public PlantIDController(IPlantIDService plantIDService)
        {
            _plantIDService = plantIDService;
        }

        [HttpPost("Identify")]
        public async Task<IActionResult> Identify([FromForm] PlantIDRequestDTO plantID)
        {
            if (plantID.File == null || plantID.File.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            try
            {
                var result = await _plantIDService.IdentifyPlantAsync(plantID.File);
                return Ok(result);
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
