using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDTO>().ReverseMap();
           

            CreateMap<Villa, VillaDTOCreate>().ReverseMap();
            CreateMap<Villa , VillaUpdateDTO>().ReverseMap();


        }
    }
}
