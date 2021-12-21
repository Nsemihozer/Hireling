using Application.Calisans;
using Application.Unvans;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CalisanDto,Calisanlar>();
            CreateMap<Calisanlar,CalisanDto>();
            CreateMap<Unvanlar,Unvanlar>();
            CreateMap<Unvanlar,UnvanDto>();

        }
    }
}