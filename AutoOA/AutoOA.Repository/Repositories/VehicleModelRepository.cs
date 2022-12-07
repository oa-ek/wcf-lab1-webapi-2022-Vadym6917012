using AutoMapper;
using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;
using AutoOA.Repository.Dto.VehicleBrandDto;
using AutoOA.Repository.Dto.VehicleModelDto;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Repository.Repositories
{
    public class VehicleModelRepository
    {
        private readonly AutoOADbContext _ctx;
        private readonly IMapper _mapper;

        public VehicleModelRepository(AutoOADbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleModelReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<VehicleModelReadDto>>(await _ctx.VehicleModels.Include(x => x.VehicleBrand).Include(x => x.Vehicles).ToListAsync());

        }

        public async Task<VehicleModel> AddVehicleModelAsync(VehicleModel model)
        {
            _ctx.VehicleModels.Add(model);
            await _ctx.SaveChangesAsync();
            return _ctx.VehicleModels.FirstOrDefault(x => x.VehicleModelName == model.VehicleModelName);
        }

        public VehicleModel GetVehicleModel(int id)
        {
            return _ctx.VehicleModels.Include(x => x.VehicleBrand).FirstOrDefault(x => x.VehicleModelId == id);
        }

        public VehicleModel GetVehicleModelByName(string name)
        {
            return _ctx.VehicleModels.Include(x => x.VehicleBrand).FirstOrDefault(x => x.VehicleModelName == name);
        }

        public List<VehicleModel> GetVehicleModels()
        {
            var modelList = _ctx.VehicleModels.ToList();
            return modelList;
        }

        public async Task<int> CreateAsync(VehicleModelCreateDto obj)
        {
            var data = await _ctx.VehicleModels.AddAsync(new VehicleModel { VehicleModelName = obj.VehicleModelName });
            await _ctx.SaveChangesAsync();
            //_ctx.BodyTypes.Find(data.Entity.BodyTypeId). = await dataContext.Statuses.FirstAsync();
            //await _ctx.SaveChangesAsync();
            return data.Entity.VehicleModelId;
        }

        public async Task<VehicleModelReadDto> GetAsync(int id)
        {
            return _mapper.Map<VehicleModelReadDto>(await _ctx.VehicleModels.Include(x => x.VehicleBrand).FirstOrDefaultAsync());
        }

        public async Task Update(int id, VehicleModelCreateDto modelDto)
        {
            var model = _ctx.VehicleModels.FirstOrDefault(x => x.VehicleModelId == id);
            model.VehicleModelName = modelDto.VehicleModelName;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteVehicleModelAsync(int id)
        {
            _ctx.Remove(GetVehicleModel(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
