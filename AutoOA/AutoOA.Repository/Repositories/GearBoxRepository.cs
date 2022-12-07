using AutoMapper;
using AutoOA.Core;
using AutoOA.Repository.Dto.FuelTypeDto;
using AutoOA.Repository.Dto.GearBoxDto;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Repository.Repositories
{
    public class GearBoxRepository
    {
        private readonly AutoOADbContext _ctx;
        private readonly IMapper _mapper;

        public GearBoxRepository(AutoOADbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GearBoxReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<GearBoxReadDto>>(await _ctx.GearBoxes.ToListAsync());
        }

        public async Task<GearBox> AddGearBoxAsync(GearBox gear)
        {
            _ctx.GearBoxes.Add(gear);
            await _ctx.SaveChangesAsync();
            return _ctx.GearBoxes.FirstOrDefault(x => x.GearBoxName == gear.GearBoxName);
        }

        public List<GearBox> GetGearBoxes()
        {
            var gearList = _ctx.GearBoxes.ToList();
            return gearList;
        }

        public GearBox GetGearBox(int id)
        {
            return _ctx.GearBoxes.FirstOrDefault(x => x.GearBoxId == id);
        }

        public GearBox GetGearBoxByName(string name)
        {
            return _ctx.GearBoxes.FirstOrDefault(x => x.GearBoxName == name);
        }

        public async Task<int> CreateAsync(GearBoxCreateDto obj)
        {
            var data = await _ctx.GearBoxes.AddAsync(new GearBox { GearBoxName = obj.GearBoxName });
            await _ctx.SaveChangesAsync();
            //_ctx.BodyTypes.Find(data.Entity.BodyTypeId). = await dataContext.Statuses.FirstAsync();
            //await _ctx.SaveChangesAsync();
            return data.Entity.GearBoxId;
        }

        public async Task<GearBoxReadDto> GetAsync(int id)
        {
            return _mapper.Map<GearBoxReadDto>(await _ctx.GearBoxes.FirstAsync());
        }

        public async Task Update(int id, GearBoxCreateDto gearBoxDto)
        {
            var gearBox = _ctx.GearBoxes.FirstOrDefault(x => x.GearBoxId == id);
            gearBox.GearBoxName = gearBoxDto.GearBoxName;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteGearBoxAsync(int id)
        {
            _ctx.Remove(GetGearBox(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
