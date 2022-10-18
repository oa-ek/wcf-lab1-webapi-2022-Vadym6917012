using AutoOA.Core;
using AutoOA.Repository.Dto.VehicleDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Repository.Repositories
{
    public class VehicleRepository
    {
        private readonly AutoOADbContext _ctx;
        private readonly VehicleModelRepository _vehicleModelRepository;

        public VehicleRepository(AutoOADbContext ctx, VehicleModelRepository vehicleModelRepository)
        {
            _ctx = ctx;
            _vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<IEnumerable<VehicleReadDto>> GetVehicleAsync()
        {
            var vehicles = new List<VehicleReadDto>();

            foreach (var u in _ctx.Vehicles.ToList())
            {
                var vehiclesDto = new VehicleReadDto
                {
                    VehicleId = u.VehicleId,
                    BodyTypeId = u.BodyTypeId,
                    ModelId = u.VehicleModelId,
                    GearBoxId = u.GearBoxId,
                    Price = u.Price,
                    isNew = u.isNew,
                    Mileage = u.Mileage,
                    IconPath = u.IconPath,
                    FuelTypeId = u.FuelTypeId,
                };
                vehicles.Add(vehiclesDto);
            }

            return vehicles;
        }

        public async Task<IEnumerable<VehicleModel>> GetModelsAsync()
        {
            return await _ctx.VehicleModels.ToListAsync();
        }
    }
}
