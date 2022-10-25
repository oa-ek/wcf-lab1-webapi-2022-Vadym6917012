using AutoOA.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoOA.Repository.Repositories;
using AutoOA.Repository.Dto.VehicleDto;
using AutoOA.Core;
using AutoOA.Repository.Dto.UserDto;

namespace AutoOA.UI.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ILogger<VehiclesController> _logger;

        private readonly VehicleRepository _vehicleRepository;
        private readonly VehicleModelRepository _vehicleModelRepository;
        private readonly VehicleBrandRepository _vehicleBrandRepository;
        private readonly FuelTypeRepository _fuelTypeRepository;
        private readonly GearBoxRepository _gearBoxRepository;
        private readonly DriveTypeRepository _driveTypeRepository;
        private readonly BodyTypeRepository _bodyTypeRepository;

        public VehiclesController(ILogger<VehiclesController> logger, VehicleRepository vehicleRepository, 
            VehicleModelRepository vehicleModelRepository, VehicleBrandRepository vehicleBrandRepository,
            FuelTypeRepository fuelTypeRepository, GearBoxRepository gearBoxRepository,
            DriveTypeRepository driveTypeRepository,BodyTypeRepository bodyTypeRepository )
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleBrandRepository = vehicleBrandRepository;
            _fuelTypeRepository = fuelTypeRepository;
            _gearBoxRepository = gearBoxRepository;
            _driveTypeRepository = driveTypeRepository;
            _bodyTypeRepository = bodyTypeRepository;
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

        public async Task<IActionResult> Sellcar()
        {
            ViewBag.Models = await _vehicleModelRepository.GetVehicleModelsAsync();
            ViewBag.Brands = await _vehicleBrandRepository.GetVehicleBrandsAsync();
            ViewBag.FuelTypes = await _fuelTypeRepository.GetFuelTypesAsync();
            ViewBag.GearBoxes = await _gearBoxRepository.GetGearBoxesAsync();
            ViewBag.DriveTypes = await _driveTypeRepository.GetDriveTypesAsync();
            ViewBag.BodyTypes = await _bodyTypeRepository.GetBodyTypesAsync();
            return View();
        }

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> Sellcar(VehicleCreateDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Vehicle vehicle = await _vehicleRepository.AddVehicleAsync();
        //        //return RedirectToAction("Index", "Vehicles", new { id = vehicle.VehicleId });
        //    }
        //    return View(model);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
