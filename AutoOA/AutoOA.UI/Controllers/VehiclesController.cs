using AutoOA.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoOA.Repository.Repositories;
using AutoOA.Repository.Dto.VehicleDto;

namespace AutoOA.UI.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly VehicleModelRepository _vehicleModelRepository;

        public VehiclesController(VehicleRepository vehicleRepository, VehicleModelRepository vehicleModelRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _vehicleRepository.GetVehiclesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Models = await _vehicleModelRepository.GetVehicleModelAsync(id);
            return View(await _vehicleRepository.GetVehicleAsync(id));
        }


        public async Task<IActionResult> Create()
        {
            return View(await _vehicleRepository.GetVehiclesAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
