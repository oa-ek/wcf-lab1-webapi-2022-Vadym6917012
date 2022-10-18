using AutoOA.Core;
using AutoOA.Repository.Dto.FuelTypeDto;

namespace AutoOA.Repository.Repositories
{
    public class FuelTypeRepository
    {
        private readonly AutoOADbContext _ctx;

        public FuelTypeRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<FuelTypeReadDto>> GetFuelTypesAsync()
        {
            var fuels = new List<FuelTypeReadDto>();

            foreach (var u in _ctx.FuelTypes.ToList())
            {
                var fuelsDto = new FuelTypeReadDto
                {
                    FuelTypeId = u.FuelTypeId,
                    FuelTypeName = u.FuelName,
                    VehileId = u.VehicleId
                };

                fuels.Add(fuelsDto);
            }

            return fuels;
        }
    }
}
