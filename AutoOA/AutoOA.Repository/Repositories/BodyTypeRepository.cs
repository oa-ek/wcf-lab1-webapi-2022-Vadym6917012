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
            var bodyDto = _ctx.BodyTypes.
                Select(x => new BodyTypeReadDto { 
                    BodyId = x.BodyTypeId, 
                    BodyName = x.BodyTypeName, 
                    Vehicle = x.Vehicle }).ToList();

            return bodyDto;
        }
    }
}
