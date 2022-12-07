using AutoOA.Core;
using AutoOA.Repository.Dto.GearBoxDto;
using AutoOA.Repository.Dto.VehicleBrandDto;
using AutoOA.Repository.Dto.VehicleDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleBrandController : ControllerBase
    {
        private readonly ILogger<VehicleBrandController> _logger;
        private readonly VehicleBrandRepository _vehicleBrandRepository;
        private readonly AutoOADbContext _ctx;

        public VehicleBrandController(ILogger<VehicleBrandController> logger, VehicleBrandRepository vehicleBrandRepository, AutoOADbContext ctx)
        {
            _logger = logger;
            _vehicleBrandRepository = vehicleBrandRepository;
            _ctx = ctx;
        }
        [HttpGet]
        public async Task<IEnumerable<VehicleBrandReadDto>> GetListAsync()
        {
            return await _vehicleBrandRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<VehicleBrandReadDto> GetById(int id)
        {
            return await _vehicleBrandRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<int> Create(VehicleBrandCreateDto brandDto)
        {
            return await _vehicleBrandRepository.CreateAsync(brandDto);
        }
    
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] VehicleBrandCreateDto brandDto)
        {
            await _vehicleBrandRepository.Update(id, brandDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _ctx.VehicleBrands.FindAsync(id);

            if (item is null)
            {
                return NotFound();
            }
            await _vehicleBrandRepository.DeleteVehicleBrandAsync(id);

            return NoContent();
        }
    }
}

