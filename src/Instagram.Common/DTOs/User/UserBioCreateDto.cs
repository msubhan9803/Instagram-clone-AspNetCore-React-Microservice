using System;

namespace Instagram.Common.DTOs.User
{
    public class UserBioCreateDto
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public string Gender { get; set; }
        public string WebsiteUrl { get; set; }
    }
}