using AutoOA.Core;
using AutoOA.Repository.Dto.VehicleDto;
using AutoOA.Repository.Dto.VehicleModelDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly VehicleRepository _vehicleRepository;
        private readonly AutoOADbContext _ctx;

        public VehicleController(ILogger<VehicleController> logger, VehicleRepository vehicleRepository, AutoOADbContext ctx)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleReadDto>> GetListAsync()
        {
            return await _vehicleRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<VehicleReadDto> GetById(int id)
        {
            return await _vehicleRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<Vehicle> Create(Vehicle vehicleDto)
        {
            return await _vehicleRepository.AddVehicleAsync(vehicleDto);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] VehicleReadDto vehicleDto, string regionName, string bodyTypeName,
            string vehicleBrandName, string vehicleModelName, string gearBoxName, string driveTypeName, string fuelTypeName)
        {
            await _vehicleRepository.UpdateAsync(id, vehicleDto, regionName, bodyTypeName,
             vehicleBrandName, vehicleModelName, gearBoxName, driveTypeName, fuelTypeName);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _ctx.Vehicles.FindAsync(id);

            if (item is null)
            {
                return NotFound();
            }
            await _vehicleRepository.DeleteVehicleAsync(id);

            return NoContent();
        }
    }
}
