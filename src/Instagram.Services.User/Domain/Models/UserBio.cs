using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Services.User.Domain.Models
{
    public class UserBio
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Text { get; protected set; }
        public string Gender { get; protected set; }
        public string WebsiteUrl { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected UserBio()
        {
            
        }

        public UserBio(Guid userId, string text, string gender, 
            string websiteUrl)
        {
            Id = new Guid();
            UserId = userId;
            Text = text;
            Gender = gender;
            WebsiteUrl = websiteUrl;
            CreatedAt = DateTime.UtcNow;
        }
    }
}