using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Services.Post.Domain.Models
{
    [Table("UserPosts")]
    public class UserPost
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Caption { get; set; }
        public Guid FileId { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserPost(Guid userId, string caption, Guid fileId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Caption = caption;
            FileId = fileId;
            CreatedAt = DateTime.UtcNow;
            CreatedAt = new DateTime(
                                CreatedAt.Year, 
                                CreatedAt.Month, 
                                CreatedAt.Day, 
                                CreatedAt.Hour, 
                                CreatedAt.Minute, 
                                CreatedAt.Second, 
                                CreatedAt.Kind
                            );
        }
    }
}