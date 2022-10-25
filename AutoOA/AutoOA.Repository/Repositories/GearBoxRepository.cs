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

        public async Task<GearBox> AddGearBoxAsync(GearBox gear)
        {
            _ctx.GearBoxes.Add(gear);
            await _ctx.SaveChangesAsync();
            return _ctx.GearBoxes.FirstOrDefault(x => x.GearBoxName == gear.GearBoxName);
        }

        public async Task DeleteGearBoxAsync(int id)
        {
            _ctx.GearBoxes.Remove(GetGearBoxById(id));
            await _ctx.SaveChangesAsync();
        }

        public GearBox GetGearBoxById(int id)
        {
            return _ctx.GearBoxes.FirstOrDefault(x => x.GearBoxId == id);
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
