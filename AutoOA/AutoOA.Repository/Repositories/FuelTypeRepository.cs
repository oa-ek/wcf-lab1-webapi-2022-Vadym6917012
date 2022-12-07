﻿using AutoMapper;
using AutoOA.Core;
using AutoOA.Repository.Dto.DriveTypeDto;
using AutoOA.Repository.Dto.FuelTypeDto;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Repository.Repositories
{
    public class FuelTypeRepository
    {
        private readonly AutoOADbContext _ctx;
        private readonly IMapper _mapper;

        public FuelTypeRepository(AutoOADbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuelTypeReadDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<FuelTypeReadDto>>(await _ctx.FuelTypes.ToListAsync());
        }

        public async Task<FuelType> AddFuelTypeAsync(FuelType type)
        {
            _ctx.FuelTypes.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.FuelTypes.FirstOrDefault(x => x.FuelTypeName == type.FuelTypeName);
        }

        public List<FuelType> GetFuelTypes()
        {
            var typeList = _ctx.FuelTypes.ToList();
            return typeList;
        }

        public FuelType GetFuelType(int id)
        {
            return _ctx.FuelTypes.FirstOrDefault(x => x.FuelTypeId == id);
        }

        public FuelType GetFuelTypeByName(string name)
        {
            return _ctx.FuelTypes.FirstOrDefault(x => x.FuelTypeName == name);
        }

        public async Task<int> CreateAsync(FuelTypeCreateDto obj)
        {
            var data = await _ctx.FuelTypes.AddAsync(new FuelType { FuelTypeName = obj.FuelTypeName });
            await _ctx.SaveChangesAsync();
            //_ctx.BodyTypes.Find(data.Entity.BodyTypeId). = await dataContext.Statuses.FirstAsync();
            //await _ctx.SaveChangesAsync();
            return data.Entity.FuelTypeId;
        }

        public async Task<FuelTypeReadDto> GetAsync(int id)
        {
            return _mapper.Map<FuelTypeReadDto>(await _ctx.FuelTypes.FirstAsync());
        }

        public async Task Update(int id, FuelTypeCreateDto fuelTypeDto)
        {
            var fuelType = _ctx.FuelTypes.FirstOrDefault(x => x.FuelTypeId == id);
            fuelType.FuelTypeName = fuelTypeDto.FuelTypeName;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteFuelTypeAsync(int id)
        {
            _ctx.Remove(GetFuelType(id));
            await _ctx.SaveChangesAsync();
        }
    }
}
