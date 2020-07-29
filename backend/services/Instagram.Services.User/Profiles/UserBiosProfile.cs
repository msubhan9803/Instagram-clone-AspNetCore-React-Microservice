using AutoMapper;
using Instagram.Common.DTOs.User;
using Instagram.Services.User.Domain.Models;
using model = Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Profiles
{
    public class UserBiosProfile : Profile
    {
        public UserBiosProfile()
        {
            //Source -> Target
            CreateMap<UserBioCreateDto, UserBio>();
            CreateMap<UserBio, UserBioReadDto>();
            CreateMap<UserBio, UserBioUpdateDto>();
            CreateMap<UserBioUpdateDto, UserBio>();
        }

    }
    
}