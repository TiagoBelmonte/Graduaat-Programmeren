using AutoMapper;
using Assignment.Domain.Models;
using Assignment.REST.DTO;

namespace Assignment.REST.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // REST mapping
            CreateMap<KlantDTO, Klant>().ReverseMap();
            // EF mapping
            CreateMap<Assignment.Repository.Models.Klanten, Klant>().ReverseMap();
        }
    }
}
