using System;

namespace Instagram.Common.DTOs.User
{
    public class UserRelationCreateDto
    {
        public Guid UserId { get; set; }
        public Guid FollowedUserId { get; set; }
    }
}