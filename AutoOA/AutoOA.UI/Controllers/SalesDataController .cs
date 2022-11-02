using AutoOA.Core;
using AutoOA.Repository.Dto.SalesDataDto;
using AutoOA.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AutoOA.UI.Controllers
{
    public class SalesDataController : Controller
    {
        private readonly ILogger<SalesDataController> _logger;
        private readonly SalesDataRepository _SalesDataRepository;
        public SalesDataController(ILogger<SalesDataController> logger, SalesDataRepository SalesDataRepository)
        {
            _logger = logger;
            _SalesDataRepository = SalesDataRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(SalesDataCreateDto salesDataCreateDto)
        {
            if (ModelState.IsValid)
            {
                var fuelType = await _SalesDataRepository.GetDataByCreatedData(new SalesData
                {
                    
                });
                return RedirectToAction("Index", "Sales Data", new { id = fuelType.RegionId });
            }
            return View(salesDataCreateDto);
        }
    }
}
