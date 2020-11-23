using AutoMapper;
using Instagram.Common.DTOs.Post;
using Instagram.Services.Post.Domain.Models;

namespace Instagram.Services.Post.Profiles
{
    public class PostLikeProfile : Profile
    {
        public PostLikeProfile()
        {
            //Source -> Target
            CreateMap<PostLike, PostLikeReadDto>();
        }

    }
    
}