using System;

namespace Instagram.Common.DTOs.User
{
    public class UserBioReadDto
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string ProfileImageName { get; set; }
        public string Text { get; protected set; }
        public string Gender { get; protected set; }
        public string WebsiteUrl { get; protected set; }
    }
}