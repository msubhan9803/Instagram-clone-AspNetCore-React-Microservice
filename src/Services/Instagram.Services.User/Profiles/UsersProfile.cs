using AutoMapper;
using Instagram.Common.DTOs.User;
using Instagram.Services.User.Domain.Models;
using model = Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            //Source -> Target
            CreateMap<model.User, UserReadDto>();
        }

    }
    
}