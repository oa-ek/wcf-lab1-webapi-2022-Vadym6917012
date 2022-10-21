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

        public async Task<IEnumerable<VehicleReadDto>> GetVehiclesAsync()
        {
            var vehicleDto  = _ctx.Vehicles
                .Select(x => new VehicleReadDto{ 
                    VehicleId = x.VehicleId,
                    BodyType = x.BodyType, 
                    VehicleModel = x.VehicleModel,
                    DriveType = x.DriveType,
                    ProductionDate = x.ProductionDate,
                    GearBox = x.GearBox, 
                    VehicleBrand = x.VehicleModel.VehicleBrand.VehicleBrandName,
                    Price = x.Price, 
                    isNew = x.isNew,
                    MileageIconPath = x.MileageIconPath,
                    Mileage = x.Mileage,
                    VehicleIconPath = x.VehicleIconPath,
                    FuelType = x.FuelType, 
                    Color = x.Color,
                    Description = x.Description}).ToList();

            return vehicleDto;
        }

        public async Task<VehicleReadDto> GetVehicleAsync(int id)
        {
            var u = await _ctx.Vehicles.Include(x => x.VehicleModel).ThenInclude(x => x.VehicleBrand).FirstAsync(x => x.VehicleId == id);

            var vehicleDto = new VehicleReadDto
            {
                VehicleId = u.VehicleId,
                BodyType = u.BodyType,
                VehicleModel = u.VehicleModel,
                VehicleBrand = u.VehicleModel.VehicleBrand.VehicleBrandName,
                DriveType = u.DriveType,
                ProductionDate = u.ProductionDate,
                Price = u.Price,
                isNew = u.isNew,
                MileageIconPath = u.MileageIconPath,
                Mileage = u.Mileage,
                VehicleIconPath = u.VehicleIconPath,
                FuelType = u.FuelType,
                Color = u.Color,
                Description = u.Description
            };

            return vehicleDto;
        }
    }
}
