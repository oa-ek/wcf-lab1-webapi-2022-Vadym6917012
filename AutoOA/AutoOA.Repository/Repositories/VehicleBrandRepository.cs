using AutoMapper;
using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Dto.RegionDto;
using AutoOA.Repository.Dto.VehicleBrandDto;
using AutoOA.Repository.Dto.VehicleDto;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Repository.Repositories
{
    public class VehicleBrandRepository
    {
        private readonly AutoOADbContext _ctx;
        private readonly IMapper _mapper;

        public VehicleBrandRepository(AutoOADbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleBrandReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<VehicleBrandReadDto>>(await _ctx.VehicleBrands.ToListAsync());

        }

        public async Task<VehicleBrand> AddVehicleBrandAsync(VehicleBrand type)
        {
            _ctx.VehicleBrands.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.VehicleBrands.FirstOrDefault(x => x.VehicleBrandName == type.VehicleBrandName);
        }

        public List<VehicleBrand> GetVehicleBrands()
        {
            var brandList = _ctx.VehicleBrands.ToList();
            return brandList;
        }

        public VehicleBrand GetVehicleBrand(int id)
        {
            return _ctx.VehicleBrands.FirstOrDefault(x => x.VehicleBrandId == id);
        }

        public VehicleBrand GetVehicleBrandByName(string name)
        {
            return _ctx.VehicleBrands.FirstOrDefault(x => x.VehicleBrandName == name);
        }

        public async Task<int> CreateAsync(VehicleBrandCreateDto obj)
        {
            var data = await _ctx.VehicleBrands.AddAsync(new VehicleBrand { VehicleBrandName = obj.VehicleBrandName });
            await _ctx.SaveChangesAsync();
            //_ctx.BodyTypes.Find(data.Entity.BodyTypeId). = await dataContext.Statuses.FirstAsync();
            //await _ctx.SaveChangesAsync();
            return data.Entity.VehicleBrandId;
        }

        public async Task<VehicleBrandReadDto> GetAsync(int id)
        {
            return _mapper.Map<VehicleBrandReadDto>(await _ctx.VehicleBrands.Include(x => x.VehicleModels).FirstAsync());
        }

        public async Task Update(int id, VehicleBrandCreateDto brandDto)
        {
            var brand = _ctx.VehicleBrands.FirstOrDefault(x => x.VehicleBrandId == id);
            brand.VehicleBrandName = brandDto.VehicleBrandName;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteVehicleBrandAsync(int id)
        {
            _ctx.Remove(GetVehicleBrand(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
