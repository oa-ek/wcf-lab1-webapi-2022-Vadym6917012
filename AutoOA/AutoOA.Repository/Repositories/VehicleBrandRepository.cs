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
            var brands = new List<VehicleBrandReadDto>();

            foreach (var u in _ctx.VehicleBrands.ToList())
            {
                var brandsDto = new VehicleBrandReadDto
                {
                    VehicleBrandId = u.VehicleBrandId,
                    VehicleBrandName = u.VehicleBrandName
                };

                brands.Add(brandsDto);
            }

            return brands;
        }
    }
}
