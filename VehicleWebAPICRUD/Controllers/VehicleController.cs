using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleWebAPICRUD.Data;
using VehicleWebAPICRUD.Interfaces;
using VehicleWebAPICRUD.Models;
using VehicleWebAPICRUD.VehicleDBContext;

namespace VehicleWebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _context;
        public VehicleController (IVehicleService context)
        {
            _context = context;
        }

        [HttpGet("Get-All")]
        public async Task<ActionResult> GetAllVehicle()
        {
            var data = await _context.GetAllVehicle();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetVehicleById(int id)
        {
            var data = await _context.GetVehicleById(id);
            return Ok(data);
        }

        [HttpGet("Get-ByPage")]
        public async Task<ActionResult> GetPage(int pageNumber, int pageSize)
        {
            var data = await _context.GetPage(pageNumber, pageSize);
            return Ok(data);    
        }

        [HttpPost("Create-Details")]
        public async Task<ActionResult> CreateDetail(vehicle std)
        {
            await _context.CreateDetail(std);
            return Ok();
        }

        [HttpPut("Update-Details")]
        public async Task<ActionResult> UpdateDetail(UpdateRequest req)
        {
            var data = await _context.UpdateDetail(req);
            return Ok(data);
        }

        [HttpDelete("Delete-Details")]
        public async Task<ActionResult> DeleteDetail(int id)
        {
            await _context.DeleteDetail(id);
            return Ok();
        }

    }
}
