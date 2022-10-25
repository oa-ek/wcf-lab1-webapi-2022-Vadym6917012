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

        public async Task<FuelType> AddFuelTypeAsync(FuelType type)
        {
            _ctx.FuelTypes.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.FuelTypes.FirstOrDefault(x => x.FuelName == type.FuelName);
        }

        public async Task DeleteFuelTypeAsync(int id)
        {
            _ctx.FuelTypes.Remove(GetFuelTypeById(id));
            await _ctx.SaveChangesAsync();
        }

        public FuelType GetFuelTypeById(int id)
        {
            return _ctx.FuelTypes.FirstOrDefault(x => x.FuelTypeId == id);
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
