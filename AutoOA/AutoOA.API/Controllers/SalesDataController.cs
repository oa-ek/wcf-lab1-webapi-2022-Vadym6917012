using AutoOA.Core;
using AutoOA.Repository.Dto.SalesDataDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesDataController : ControllerBase
    {
        private readonly ILogger<SalesDataController> _logger;
        private readonly SalesDataRepository _salesDataRepository;

        public SalesDataController(ILogger<SalesDataController> logger, SalesDataRepository salesDataRepository)
        {
            _logger = logger;
            _salesDataRepository = salesDataRepository;
        }

        //[HttpGet("GetSalesData")]
        //public async Task<IEnumerable<SalesDataReadDto>> GetListAsync()
        //{
        //    //return await _salesDataRepository.GetSaleDatas();
        //}
    }
}
