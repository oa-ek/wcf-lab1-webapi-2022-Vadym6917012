using AutoOA.Core;
using AutoOA.Repository.Dto.GearBoxDto;

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
            var gears = new List<GearBoxReadDto>();

            foreach (var u in _ctx.GearBoxes.ToList())
            {
                var gearsDto = new GearBoxReadDto
                {
                    GearBoxId = u.GearBoxId,
                    GearBoxName = u.GearBoxName,
                    VehicleId = u.VehicleId
                };

                gears.Add(gearsDto);
            }

            return gears;
        }
    }
}
