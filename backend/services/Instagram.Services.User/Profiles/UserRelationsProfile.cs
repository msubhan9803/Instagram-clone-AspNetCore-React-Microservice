using AutoMapper;
using Instagram.Common.DTOs.User;
using Instagram.Services.User.Domain.Models;

namespace Instagram.Services.User.Profiles
{
    public class UserRelationsProfile : Profile
    {
        public UserRelationsProfile()
        {
            //Source -> Target
            CreateMap<UserRelationCreateDto, UserRelation>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.FollowedUserId))
            .ForMember(dest => dest.FollowerId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<UserRelation, UserRelationReadDto>();
        }
    }
}