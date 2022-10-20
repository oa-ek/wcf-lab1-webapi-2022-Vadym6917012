using AutoOA.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoOA.Repository.Repositories;
using AutoOA.Repository.Dto.FuelTypeDto;

namespace AutoOA.UI.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehiclesController(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
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
