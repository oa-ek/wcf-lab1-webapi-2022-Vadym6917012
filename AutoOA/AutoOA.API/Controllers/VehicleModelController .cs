using AutoOA.Core;
using AutoOA.Repository.Dto.VehicleBrandDto;
using AutoOA.Repository.Dto.VehicleDto;
using AutoOA.Repository.Dto.VehicleModelDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly ILogger<VehicleModelController> _logger;
        private readonly VehicleModelRepository _vehicleModelRepository;
        private readonly AutoOADbContext _ctx;

        public VehicleModelController(ILogger<VehicleModelController> logger, VehicleModelRepository vehicleModelRepository, AutoOADbContext ctx)
        {
            _logger = logger;
            _vehicleModelRepository = vehicleModelRepository;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleModelReadDto>> GetListAsync()
        {
            return await _vehicleModelRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<VehicleModelReadDto> GetById(int id)
        {
            return await _vehicleModelRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<int> Create(VehicleModelCreateDto modelDto)
        {
            return await _vehicleModelRepository.CreateAsync(modelDto);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] VehicleModelCreateDto modelDto)
        {
            await _vehicleModelRepository.Update(id, modelDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _ctx.VehicleModels.FindAsync(id);

            if (item is null)
            {
                return NotFound();
            }
            await _vehicleModelRepository.DeleteVehicleModelAsync(id);

            return NoContent();
        }
    }
}
