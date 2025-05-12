using AutoMapper;
using AuthService.Dtos;
using AuthService.RequestModels;

namespace AuthService.Mappings
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterRequest, RegisterDto>();
            CreateMap<LoginRequest, LoginDto>();
        }
    }
}