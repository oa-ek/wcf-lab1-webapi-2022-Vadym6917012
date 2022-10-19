using AutoOA.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoOA.Repository.Repositories;

namespace AutoOA.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly VehicleRepository _vehicleRepository;
        private readonly BodyTypeRepository _bodyTypeRepository;

        public HomeController(ILogger<HomeController> logger, VehicleRepository vehicleRepository, BodyTypeRepository bodyTypeRepository)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
            _bodyTypeRepository = bodyTypeRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.BodyTypes = await _bodyTypeRepository.GetBodyTypesAsync();
            return View(await _vehicleRepository.GetVehicleAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}