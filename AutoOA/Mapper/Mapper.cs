using AutoMapper;
using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;

namespace AutoOA.Server.Infastructure
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<BodyTypeReadDto, BodyType>();
            CreateMap<BodyType, BodyTypeReadDto>();
        }
    }
}