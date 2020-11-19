using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Services.User.Domain.Models
{
    public class UserBio
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ProfileImageName { get; set; }
        public string Text { get; set; }
        public string Gender { get; set; }
        public string WebsiteUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        UserBio()
        {
            
        }

        public UserBio(Guid userId, string profileImageName, string text, string gender, 
            string websiteUrl)
        {
            Id = new Guid();
            UserId = userId;
            ProfileImageName = profileImageName;
            Text = text;
            Gender = gender;
            WebsiteUrl = websiteUrl;
            CreatedAt = DateTime.UtcNow;
        }
    }
}