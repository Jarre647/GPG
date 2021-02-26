using AutoMapper;
using System.Collections.Generic;
using System;
using SQL_Repository.Models;
using SQLRepository.Client.Models;

namespace SQL_Repository.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GrudgeModel, GrudgeModel>();
        }
    }
}
