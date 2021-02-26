using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SQLRepository.Client.Models;
using WebReact.Models;

namespace WebReact.Mappings
{
    public class MappingEntityConfig : Profile
    {
        public MappingEntityConfig()
        {
            CreateMap<GrudgeModel, DbGrudgesModel>().ReverseMap();
        }
    }
}
