using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyTypeController : ControllerBase
    {
        private readonly ILogger<BodyTypeController> _logger;
        private readonly BodyTypeRepository _bodyTypeRepository;
        private readonly AutoOADbContext _ctx;

        public BodyTypeController(ILogger<BodyTypeController> logger, BodyTypeRepository bodyTypeRepository, AutoOADbContext ctx)
        {
            _logger = logger;
            _bodyTypeRepository = bodyTypeRepository;
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IEnumerable<BodyTypeReadDto>> GetListAsync()
        {
            return await _bodyTypeRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<BodyTypeReadDto> GetBodyTypeById(int id)
        {
            return await _bodyTypeRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<int> Create(BodyTypeCreateDto bodyType)
        {
            return await _bodyTypeRepository.CreateAsync(bodyType);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] BodyTypeCreateDto bodyType)
        {
             await _bodyTypeRepository.Update(id, bodyType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _ctx.BodyTypes.FindAsync(id);

            if (item is null)
            {
                return NotFound();
            }
            await _bodyTypeRepository.DeleteBodyTypeAsync(id);

            return NoContent();
        }
    }
}
