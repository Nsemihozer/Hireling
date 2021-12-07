using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Calisanlar,Calisanlar>();
            CreateMap<Unvanlar,Unvanlar>();
        }
    }
}