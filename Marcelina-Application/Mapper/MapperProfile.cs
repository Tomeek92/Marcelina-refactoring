using AutoMapper;
using Marcelina_Application.Dto;
using Marcelina_Domain.Enties.Szkolenia;
using Marcelina_Domain.Enties.Users;
using Marcelina_Domain.Uslugi;

namespace Marcelina_Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<UslugaDto, Usluga>();
            CreateMap<SzkolenieDto, Szkolenie>();
        }
    }
}