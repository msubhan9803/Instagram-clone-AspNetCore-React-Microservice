using System;

namespace Instagram.Common.DTOs.Post
{
    public class PostLikeReadDto
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}