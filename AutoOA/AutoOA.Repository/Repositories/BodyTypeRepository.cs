using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;

namespace AutoOA.Repository.Repositories
{
    public class BodyTypeRepository
    {
        private readonly AutoOADbContext _ctx;

        public BodyTypeRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<BodyTypeReadDto>> GetBodyTypesAsync()
        {
            var bodies = new List<BodyTypeReadDto>();

            foreach (var u in _ctx.BodyTypes.ToList())
            {
                var bodiesDto = new BodyTypeReadDto
                {
                    BodyId = u.BodyTypeId,
                    BodyName = u.BodyTypeName,
                    VehicleId = u.VehicleId,
                };

                bodies.Add(bodiesDto);
            }

            return bodies;
        }
    }
}
