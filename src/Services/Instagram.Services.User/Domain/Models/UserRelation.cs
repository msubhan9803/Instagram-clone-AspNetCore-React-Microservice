using System;

namespace Instagram.Services.User.Domain.Models
{
    public class UserRelation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid FollowerId { get; set; }
        public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;

        UserRelation()
        {
            
        }
    }
}