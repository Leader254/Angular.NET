using AuthenticationAPI.Models;
using AuthenticationAPI.Models.Dtos;
using AutoMapper;

namespace AuthenticationAPI.Profiles
{
  public class AuthProfiles : Profile
  {
    public AuthProfiles()
    {
        CreateMap<RegisterUserDto, ApplicationUser>()
          .ForMember(dest => dest.UserName, u => u.MapFrom(reg => reg.Email));
        CreateMap<ApplicationUser, UserDto>().ReverseMap();
    }
  }
}
