using System;

namespace Instagram.Common.DTOs.User
{
    public class UserRelationReadDto
    {
        public Guid UserId { get; set; }
        public Guid FollowerId { get; set; }
        public int Relation { get; set; }
    }
}