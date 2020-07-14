using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Services.Post.Domain.Models
{
    [Table("UserPosts")]
    public class UserPost
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Type { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Url { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        // public DateTime UpdatedAt { get; protected set; }

        protected UserPost()
        {
            
        }

        public UserPost(Guid userId, string type, string title,
            string description, string url)
        {
            Id = new Guid();
            UserId = userId;
            Type = type;
            Title = title;
            Description = description;
            Url = url;
            CreatedAt = DateTime.UtcNow;
        }
    }
}