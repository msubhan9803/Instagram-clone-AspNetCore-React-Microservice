using AutoMapper;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Post.Domain.Models;

namespace Instagram.Services.User.Profiles
{
    public class UserPostProfile : Profile
    {
        public UserPostProfile()
        {
            //Source -> Target
            CreateMap<UserPost, UserPostReadDto>();
            CreateMap<UserPostCreateDto, UserPost>();
            CreateMap<UserPost, UserPostUpdateDto>();
            CreateMap<UserPostUpdateDto, UserPost>();
        }

    }
    
}