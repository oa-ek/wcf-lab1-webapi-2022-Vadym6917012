using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Dto.VehicleModelDto;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Repository.Repositories
{
    public class VehicleModelRepository
    {
        private readonly AutoOADbContext _ctx;

        public VehicleModelRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<VehicleModelReadDto>> GetVehicleModelsAsync()
        {
            var modelDto = _ctx.VehicleModels
                .Select(x => new VehicleModelReadDto { 
                    VehicleModelId = x.VehicleModelId, 
                    VehicleModelName = x.VehicleModelName,  
                    VehicleBrandId = x.VehicleBrandId, 
                    VehicleBrand = x.VehicleBrand, 
                    Vehicles = x.Vehicles}).ToList();

            return modelDto;
        }

        public async Task<VehicleModelReadDto> GetVehicleModelAsync(int id)
        {
            var u = await _ctx.VehicleModels.FirstAsync(x => x.VehicleModelId == id);

            var modelDto = new VehicleModelReadDto
            {
                VehicleModelId= u.VehicleModelId,
                VehicleModelName = u.VehicleModelName,
                VehicleBrandId = u.VehicleBrandId,
                VehicleBrand = u.VehicleBrand,
                Vehicles = u.Vehicles
            };

            return modelDto;
        }
    }
}
