using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Dto.GearBoxDto;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Repository.Repositories
{
    public class GearBoxRepository
    {
        private readonly AutoOADbContext _ctx;

        public GearBoxRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<GearBoxReadDto>> GetGearBoxesAsync()
        {
            var gearDto = _ctx.GearBoxes.
                Select(x => new GearBoxReadDto {
                    GearBoxId = x.GearBoxId,
                    GearBoxName = x.GearBoxName,
                    IconPath = x.IconPath,
                    Vehicles = x.Vehicle }).ToList();

            return gearDto;
        }

        public async Task<GearBoxReadDto> GetGearBoxAsync(int id)
        {
            var u = await _ctx.GearBoxes.FirstAsync(x => x.GearBoxId == id);

            var gearDto = new GearBoxReadDto
            {
                GearBoxId = u.GearBoxId,
                GearBoxName = u.GearBoxName,
                IconPath = u.IconPath,
                Vehicles = u.Vehicle
            };

            return gearDto;
        }
    }
}
