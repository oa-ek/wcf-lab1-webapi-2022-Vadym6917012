using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Dto.DriveTypeDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriveTypeController : ControllerBase
    {
        private readonly ILogger<DriveTypeController> _logger;
        private readonly DriveTypeRepository _driveTypeRepository;
        private readonly AutoOADbContext _ctx;

        public DriveTypeController(ILogger<DriveTypeController> logger, DriveTypeRepository driveTypeRepository, AutoOADbContext ctx)
        {
            _logger = logger;
            _driveTypeRepository = driveTypeRepository;
            _ctx = ctx;
        }
        [HttpGet]
        public async Task<IEnumerable<DriveTypeReadDto>> GetListAsync()
        {
            return await _driveTypeRepository.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<DriveTypeReadDto> GetBodyTypeById(int id)
        {
            return await _driveTypeRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<int> Create(DriveTypeCreateDto bodyType)
        {
            return await _driveTypeRepository.CreateAsync(bodyType);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] DriveTypeCreateDto bodyType)
        {
            await _driveTypeRepository.Update(id, bodyType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _ctx.DriveTypes.FindAsync(id);

            if (item is null)
            {
                return NotFound();
            }
            await _driveTypeRepository.DeleteDriveTypeAsync(id);

            return NoContent();
        }
    }
}
