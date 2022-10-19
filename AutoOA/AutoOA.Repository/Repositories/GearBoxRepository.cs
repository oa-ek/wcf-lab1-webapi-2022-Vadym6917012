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
            var gearDto = _ctx.GearBoxes.
                Select(x => new GearBoxReadDto { 
                    GearBoxId = x.GearBoxId, 
                    GearBoxName = x.GearBoxName, 
                    Vehicles = x.Vehicle }).ToList();

            return gearDto;
        }
    }
}
