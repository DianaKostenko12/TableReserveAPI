using AutoMapper;
using BLL.Services.Tables.Descriptors;
using DAL.Models;

namespace BLL.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateTableDescriptor, Table>();
        }
    }
}
