using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Services.Post.Domain.Models
{
    [Table("UserPosts")]
    public class UserPost
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        // public DateTime UpdatedAt { get; set; }

        UserPost()
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