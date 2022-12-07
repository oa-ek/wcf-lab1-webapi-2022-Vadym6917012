using AutoOA.Core;
using AutoOA.Repository.Dto.FuelTypeDto;
using AutoOA.Repository.Dto.GearBoxDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearBoxController : ControllerBase
    {
        private readonly ILogger<GearBoxController> _logger;
        private readonly GearBoxRepository _gearBoxRepository;
        private readonly AutoOADbContext _ctx;

        public GearBoxController(ILogger<GearBoxController> logger, GearBoxRepository gearBoxRepository, AutoOADbContext ctx)
        {
            _logger = logger;
            _gearBoxRepository = gearBoxRepository;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<GearBoxReadDto>> GetListAsync()
        {
            return await _gearBoxRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<GearBoxReadDto> GetById(int id)
        {
            return await _gearBoxRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<int> Create(GearBoxCreateDto gearType)
        {
            return await _gearBoxRepository.CreateAsync(gearType);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] GearBoxCreateDto gearType)
        {
            await _gearBoxRepository.Update(id, gearType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _ctx.GearBoxes.FindAsync(id);

            if (item is null)
            {
                return NotFound();
            }
            await _gearBoxRepository.DeleteGearBoxAsync(id);

            return NoContent();
        }
    }
}
