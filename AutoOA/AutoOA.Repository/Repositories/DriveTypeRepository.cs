using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Dto.DriveTypeDto;
using Microsoft.EntityFrameworkCore;
using DriveType = AutoOA.Core.DriveType;

namespace AutoOA.Repository.Repositories
{
    public class DriveTypeRepository
    {
        private readonly AutoOADbContext _ctx;

        public DriveTypeRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<DriveType> AddDriveTypeAsync(DriveType type)
        {
            _ctx.DriveTypes.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.DriveTypes.FirstOrDefault(x => x.DriveTypeName == type.DriveTypeName);
        }

        public async Task DeleteBodyTypeAsync(int id)
        {
            _ctx.DriveTypes.Remove(GetDriveTypeById(id));
            await _ctx.SaveChangesAsync();
        }

        public DriveType GetDriveTypeById(int id)
        {
            return _ctx.DriveTypes.FirstOrDefault(x => x.DriveTypeId == id);
        }

        public async Task<IEnumerable<DriveTypeReadDto>> GetDriveTypesAsync()
        {
            var driveDto = _ctx.DriveTypes.
                Select(x => new DriveTypeReadDto
                {
                    DriveTypeId = x.DriveTypeId,
                    DriveTypeName = x.DriveTypeName,
                    Vehicles = x.Vehicle}).ToList();

            return driveDto;
        }

        public async Task<DriveTypeReadDto> GetDriveTypeAsync(int id)
        {
            var u = await _ctx.DriveTypes.FirstAsync(x => x.DriveTypeId == id);

            var driveDto = new DriveTypeReadDto
            {
                DriveTypeId = u.DriveTypeId,
                DriveTypeName = u.DriveTypeName,
                Vehicles = u.Vehicle
            };

            return driveDto;
        }
    }
}
