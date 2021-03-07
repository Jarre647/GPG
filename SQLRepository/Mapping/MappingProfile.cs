using AutoMapper;
using SQLRepository.Client.Models;

namespace SQLRepository.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GrudgeModel, GrudgeModel>();
        }
    }
}

