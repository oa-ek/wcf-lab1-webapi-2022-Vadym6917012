using AutoOA.Core;
using AutoOA.Repository.Dto.VehicleModelDto;

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
    }
}
