using AutoOA.Core;
using AutoOA.Repository.Dto.VehicleDto;

namespace AutoOA.Repository.Repositories
{
    public class VehicleRepository
    {
        private readonly AutoOADbContext _ctx;

        public VehicleRepository(AutoOADbContext ctx, VehicleModelRepository vehicleModelRepository, BodyTypeRepository bodyTypeRepository)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<VehicleReadDto>> GetVehicleAsync()
        {
            var vehicleDto  = _ctx.Vehicles
                .Select(x => new VehicleReadDto{ 
                    BodyType = x.BodyType, 
                    VehicleModel = x.VehicleModel,
                    ProductionDate = x.ProductionDate,
                    GearBox = x.GearBox, 
                    VehicleBrand = x.VehicleModel.VehicleBrand.VehicleBrandName,
                    Price = x.Price, 
                    isNew = x.isNew,
                    MileageIconPath = x.MileageIconPath,
                    Mileage = x.Mileage,
                    VehcileIconPath = x.VehicleIconPath,
                    FuelType = x.FuelType, 
                    Color = x.Color }).ToList();

            return vehicleDto;
        }
    }
}
