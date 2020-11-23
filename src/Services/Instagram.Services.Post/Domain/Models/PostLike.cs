using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Services.Post.Domain.Models
{
    [Table("PostLikes")]
    public class PostLike
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public PostLike(Guid postId, Guid userId)
        {
            Id = Guid.NewGuid();
            PostId = postId;
            UserId = userId;
        }
    }
}