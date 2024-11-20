using AutoMapper;
using BLL.Services.Auth.Descriptors;
using DAL.Models;
using TableReserveAPI.DTOs;

namespace TableReserveAPI.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<RegisterRequest, RegisterDescriptor>();
            CreateMap<LoginRequest, LoginDescriptor>();

            CreateMap<Booking, BookingResponse>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(dest => dest.Table.Number));

            CreateMap<Table, TableResponse>();
        }
    }
}
