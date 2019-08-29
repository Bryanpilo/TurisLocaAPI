using AutoMapper;
using TurisLocAPI.API.DTO.User;
using TurisLocAPI.API.Models;

namespace TurisLocAPI.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
            .ForMember(m => m.UserName,
                        vm => vm.MapFrom(
                            v => v.userName))
            .ForMember(m => m.Token, opt => opt.Ignore())
            .ReverseMap();

        }
    }
}