using AutoOA.Core;
using AutoOA.Repository.Dto.VehicleBrandDto;

namespace AutoOA.Repository.Repositories
{
    public class VehicleBrandRepository
    {
        private readonly AutoOADbContext _ctx;

        public VehicleBrandRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<VehicleBrandReadDto>> GetVehicleBrandsAsync()
        {
            var brandDto = _ctx.VehicleBrands
                .Select(x => new VehicleBrandReadDto { 
                    VehicleBrandId = x.VehicleBrandId, 
                    VehicleBrandName = x.VehicleBrandName, 
                    VehicleModels = x.VehicleModels}).ToList();

            return brandDto;
        }
    }
}
