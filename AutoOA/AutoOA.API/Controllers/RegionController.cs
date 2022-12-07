using AutoOA.Core;
using AutoOA.Repository.Dto.GearBoxDto;
using AutoOA.Repository.Dto.RegionDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly ILogger<RegionController> _logger;
        private readonly RegionRepository _regionRepository;
        private readonly AutoOADbContext _ctx;

        public RegionController(ILogger<RegionController> logger, RegionRepository regionRepository, AutoOADbContext ctx)
        {
            _logger = logger;
            _regionRepository = regionRepository;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<RegionReadDto>> GetListAsync()
        {
            return await _regionRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<RegionReadDto> GetById(int id)
        {
            return await _regionRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<int> Create(RegionCreateDto regionDto)
        {
            return await _regionRepository.CreateAsync(regionDto);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] RegionCreateDto regionDto)
        {
            await _regionRepository.Update(id, regionDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _ctx.Regions.FindAsync(id);

            if (item is null)
            {
                return NotFound();
            }
            await _regionRepository.DeleteRegionAsync(id);

            return NoContent();
        }
    }
}
