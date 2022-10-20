using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Dto.FuelTypeDto;
using Microsoft.EntityFrameworkCore;

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
                    IconPath = x.IconPath,
                    Vehicles = x.Vehicle }).ToList();

            return fuelDto;
        }

        public async Task<FuelTypeReadDto> GetFuelTypeAsync(int id)
        {
            var u = await _ctx.FuelTypes.FirstAsync(x => x.FuelTypeId == id);

            var fuelDto = new FuelTypeReadDto
            {
                FuelTypeId=u.FuelTypeId,
                FuelTypeName = u.FuelName,
                IconPath = u.IconPath,
                Vehicles = u.Vehicle
            };

            return fuelDto;
        }
    }
}
