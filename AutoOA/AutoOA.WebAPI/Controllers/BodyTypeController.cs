using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AutoOA.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyTypeController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly BodyTypeRepository _bodyTypeRepository;

        public BodyTypeController(ILogger<WeatherForecastController> logger, BodyTypeRepository bodyTypeRepository)
        {
            _logger = logger;
            _bodyTypeRepository = bodyTypeRepository;
        }

        [HttpGet]
        public BodyTypeRepository GetBodyTypeRepository()
        {
            return _bodyTypeRepository;
        }

        [HttpGet(Name = "GetBodyType")]
        public async Task<IEnumerable<BodyTypeReadDto>> GetListAsync()
        {
            return await _bodyTypeRepository.GetListAsync();
        }
    }
}
