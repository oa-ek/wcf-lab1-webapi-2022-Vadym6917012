using AutoOA.Repository.Repositories;
using AutoOA.Repository.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoOA.Repository.Dto.VehicleDto;

namespace AutoOA.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;

        private readonly VehicleRepository _vehicleRepository;
        private readonly RegionRepository _regionRepository;
        private readonly VehicleModelRepository _vehicleModelRepository;
        private readonly VehicleBrandRepository _vehicleBrandRepository;
        private readonly FuelTypeRepository _fuelTypeRepository;
        private readonly GearBoxRepository _gearBoxRepository;
        private readonly DriveTypeRepository _driveTypeRepository;
        private readonly BodyTypeRepository _bodyTypeRepository;
        private readonly SalesDataRepository _salesDataRepository;
        private readonly UsersRepository _usersRepository;

        public VehicleController(ILogger<VehicleController> logger, VehicleRepository vehicleRepository,
            RegionRepository regionRepository, VehicleModelRepository vehicleModelRepository,
            VehicleBrandRepository vehicleBrandRepository, FuelTypeRepository fuelTypeRepository,
            GearBoxRepository gearBoxRepository, DriveTypeRepository driveTypeRepository, BodyTypeRepository bodyTypeRepository,
            SalesDataRepository salesDataRepository, UsersRepository usersRepository)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
            _regionRepository = regionRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleBrandRepository = vehicleBrandRepository;
            _fuelTypeRepository = fuelTypeRepository;
            _gearBoxRepository = gearBoxRepository;
            _driveTypeRepository = driveTypeRepository;
            _bodyTypeRepository = bodyTypeRepository;
            _salesDataRepository = salesDataRepository;
            _usersRepository = usersRepository;
        }

        [HttpGet(Name ="GetVehicle")]
        public IEnumerable<Vehicle> Get()
        {
            return (IEnumerable<Vehicle>)_vehicleRepository.GetVehicles();
        }
    }
}
