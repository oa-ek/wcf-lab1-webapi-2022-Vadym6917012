using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Dto.VehicleDto;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Repository.Repositories
{
    public class VehicleRepository
    {
        private readonly AutoOADbContext _ctx;

        public VehicleRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
        {
            _ctx.Vehicles.Add(vehicle);
            await _ctx.SaveChangesAsync();
            return _ctx.Vehicles.Include(x => x.VehicleModel).ThenInclude(x => x.VehicleBrand).
                Include(x => x.BodyType).
                Include(x => x.DriveType).
                Include(x => x.FuelType).
                Include(x => x.GearBox).
                Include(x => x.Region).
                Include(x => x.SalesData).
                FirstOrDefault(x => x.VehicleModel.VehicleModelName == vehicle.VehicleModel.VehicleModelName);
        }

        public async Task DeleteVehicleAsync(int id)
        {
            _ctx.Vehicles.Remove(GetVehicleById(id));
            await _ctx.SaveChangesAsync();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _ctx.Vehicles.FirstOrDefault(x => x.VehicleId == id);
        }

        public async Task<IEnumerable<VehicleReadDto>> GetVehiclesAsync()
        {
            var vehicleDto = _ctx.Vehicles
                .Select(x => new VehicleReadDto
                {
                    VehicleId = x.VehicleId,
                    FirstRegistrationDate = x.FirstRegistrationDate,
                    RegionName = x.Region.RegionName,
                    BodyTypeIconPath = x.BodyType.IconPath,
                    BodyTypeName = x.BodyType.BodyTypeName,
                    VehicleModelName = x.VehicleModel.VehicleModelName,
                    DriveTypeName = x.DriveType.DriveTypeName,
                    StateNumber = x.StateNumber,
                    ProductionDate = x.ProductionDate,
                    VehicleBrandName = x.VehicleModel.VehicleBrand.VehicleBrandName,
                    GearBoxIconPath = x.GearBox.IconPath,
                    GearBoxName = x.GearBox.GearBoxName,
                    NumberOfSeats = x.NumberOfSeats,
                    NumberOfDoors = x.NumberOfDoors,
                    Price = x.Price,
                    isNew = x.isNew,
                    MileageIconPath = x.MileageIconPath,
                    Mileage = x.Mileage,
                    VehicleIconPath = x.VehicleIconPath,
                    FuelIconPath = x.FuelType.IconPath,
                    FuelTypeName = x.FuelType.FuelName,
                    Color = x.Color,
                    Description = x.Description,
                    SalesData = x.SalesData
                }).ToList();

            return vehicleDto;
        }

        public async Task<VehicleReadDto> GetVehicleAsync(int id)
        {
            var u = await _ctx.Vehicles.Include(x => x.VehicleModel).ThenInclude(x => x.VehicleBrand).
                Include(x => x.BodyType).
                Include(x => x.DriveType).
                Include(x => x.FuelType).
                Include(x => x.GearBox).
                Include(x => x.Region).
                Include(x => x.SalesData).FirstAsync(x => x.VehicleId == id);

            var vehicleDto = new VehicleReadDto
            {
                VehicleId = u.VehicleId,
                FirstRegistrationDate = u.FirstRegistrationDate,
                RegionName = u.Region.RegionName,
                BodyTypeIconPath = u.BodyType.IconPath,
                BodyTypeName = u.BodyType.BodyTypeName,
                VehicleModelName = u.VehicleModel.VehicleModelName,
                DriveTypeName = u.DriveType.DriveTypeName,
                StateNumber = u.StateNumber,
                ProductionDate = u.ProductionDate,
                VehicleBrandName = u.VehicleModel.VehicleBrand.VehicleBrandName,
                GearBoxIconPath = u.GearBox.IconPath,
                GearBoxName = u.GearBox.GearBoxName,
                NumberOfSeats = u.NumberOfSeats,
                NumberOfDoors = u.NumberOfDoors,
                Price = u.Price,
                isNew = u.isNew,
                MileageIconPath = u.MileageIconPath,
                Mileage = u.Mileage,
                VehicleIconPath = u.VehicleIconPath,
                FuelIconPath = u.FuelType.IconPath,
                FuelTypeName = u.FuelType.FuelName,
                Color = u.Color,
                Description = u.Description,
                SalesData = u.SalesData
            };

            return vehicleDto;
        }
    }
}
