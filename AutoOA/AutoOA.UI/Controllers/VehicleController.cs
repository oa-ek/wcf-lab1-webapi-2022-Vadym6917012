using AutoOA.Core;
using AutoOA.Repository;
using AutoOA.Repository.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AutoOA.UI.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleRepository _VehicleRepository;

        public VehicleController(VehicleRepository vehicleRepository)
        {
            _VehicleRepository = vehicleRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_VehicleRepository.ToString());
        }
    }
}
