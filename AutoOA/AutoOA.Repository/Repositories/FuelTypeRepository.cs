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
            var fuelDto = _ctx.FuelTypes.
                Select(x => new FuelTypeReadDto { 
                    FuelTypeId = x.FuelTypeId, 
                    FuelTypeName = x.FuelName, 
                    Vehicles = x.Vehicle }).ToList();

            return fuelDto;
        }
    }
}
