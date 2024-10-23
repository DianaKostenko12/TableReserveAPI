using AutoMapper;
using BLL.Services.Auth.Descriptors;
using TableReserveAPI.DTOs;

namespace TableReserveAPI.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<RegisterRequest, RegisterDescriptor>();
            CreateMap<LoginRequest, LoginDescriptor>();
        }
    }
}
