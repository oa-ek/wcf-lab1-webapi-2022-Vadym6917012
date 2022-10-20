using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Dto.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
                    IconPath = x.IconPath,
                    Vehicle = x.Vehicle }).ToList();

            return bodyDto;
        }

        public async Task<BodyTypeReadDto> GetBodyTypeAsync(int id)
        {
            var u = await _ctx.BodyTypes.FirstAsync(x => x.BodyTypeId == id);

            var bodyDto = new BodyTypeReadDto
            {
                BodyId = u.BodyTypeId,
                BodyName = u.BodyTypeName,
                IconPath = u.IconPath,
                Vehicle = u.Vehicle
            };

            return bodyDto;
        }
    }
}
