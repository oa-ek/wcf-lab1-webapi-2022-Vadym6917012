using AutoMapper;
using AutoOA.Core;
using AutoOA.Repository.Dto.BodyTypeDto;

namespace AutoOA.Server.Infastructure
{
    public class AppAutoMapper : Profile
    {
        public AppAutoMapper()
        {
            CreateMap<BodyTypeReadDto, BodyType>();
            CreateMap<BodyType, BodyTypeReadDto>();
        }
    }
}