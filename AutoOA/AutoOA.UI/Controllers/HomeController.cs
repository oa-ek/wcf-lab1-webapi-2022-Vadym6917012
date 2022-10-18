using AutoOA.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoOA.Repository.Repositories;
using AutoOA.Repository.Dto;

namespace AutoOA.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly VehicleRepository _vehicleRepository;

        public HomeController(ILogger<HomeController> logger, VehicleRepository vehicleRepository)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _vehicleRepository.GetVehicleAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}