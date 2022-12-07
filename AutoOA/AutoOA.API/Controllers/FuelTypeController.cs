using AutoOA.Core;
using AutoOA.Repository.Dto.FuelTypeDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private readonly ILogger<FuelTypeController> _logger;
        private readonly FuelTypeRepository _fuelTypeRepository;
        private readonly AutoOADbContext _ctx;

        public FuelTypeController(ILogger<FuelTypeController> logger, FuelTypeRepository fuelTypeRepository, AutoOADbContext ctx)
        {
            _logger = logger;
            _fuelTypeRepository = fuelTypeRepository;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<FuelTypeReadDto>> GetListAsync()
        {
            return await _fuelTypeRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<FuelTypeReadDto> GetBodyTypeById(int id)
        {
            return await _fuelTypeRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<int> Create(FuelTypeCreateDto fuelType)
        {
            return await _fuelTypeRepository.CreateAsync(fuelType);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] FuelTypeCreateDto fuelType)
        {
            await _fuelTypeRepository.Update(id, fuelType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _ctx.FuelTypes.FindAsync(id);

            if (item is null)
            {
                return NotFound();
            }
            await _fuelTypeRepository.DeleteFuelTypeAsync(id);

            return NoContent();
        }
    }
}
