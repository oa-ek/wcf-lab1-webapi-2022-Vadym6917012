using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Dto.VehicleBrandDto;
using Microsoft.EntityFrameworkCore;

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

        public async Task<VehicleBrandReadDto> GetVehicleBrandAsync(int id)
        {
            var u = await _ctx.VehicleBrands.FirstAsync(x => x.VehicleBrandId == id);

            var brandDto = new VehicleBrandReadDto
            {
                VehicleBrandId = u.VehicleBrandId,
                VehicleBrandName = u.VehicleBrandName,
                VehicleModels = u.VehicleModels
            };

            return brandDto;
        }
    }
}
