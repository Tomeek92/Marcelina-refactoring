using AutoMapper;
using Marcelina_Application.CQRS.Command.Users.Login;
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
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UslugaDto, Usluga>();
            CreateMap<SzkolenieDto, Szkolenie>();
            CreateMap<LoginUserCommand, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}