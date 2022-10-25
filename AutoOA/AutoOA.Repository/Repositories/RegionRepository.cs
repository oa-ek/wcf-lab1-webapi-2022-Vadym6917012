using AutoOA.Core;
using AutoOA.Repository.Dto.RegionDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOA.Repository.Repositories
{
    public class RegionRepository
    {
        private readonly AutoOADbContext _ctx;

        public RegionRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            _ctx.Regions.Add(region);
            await _ctx.SaveChangesAsync();
            return _ctx.Regions.FirstOrDefault(x => x.RegionName == region.RegionName);
        }

        public async Task DeleteRegionAsync(int id)
        {
            _ctx.Regions.Remove(GetRegionById(id));
            await _ctx.SaveChangesAsync();
        }

        public Region GetRegionById(int id)
        {
            return _ctx.Regions.FirstOrDefault(x => x.RegionId == id);
        }

        public async Task<IEnumerable<RegionReadDto>> GetRegionsAsync()
        {
            var regionDto = _ctx.Regions.
                Select(x => new RegionReadDto
                {
                    RegionId = x.RegionId,
                    RegionName = x.RegionName,
                }).ToList();

            return regionDto;
        }

        public async Task<RegionReadDto> GetRegionAsync(int id)
        {
            var u = await _ctx.Regions.FirstAsync(x => x.RegionId == id);

            var regionDto = new RegionReadDto
            {
                RegionId = u.RegionId,
                RegionName = u.RegionName
            };

            return regionDto;
        }
    }
}
