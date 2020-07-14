using System;

namespace Instagram.Common.DTOs.User
{
    public class UserBioUpdateDto
    {
        public Guid UserId { get; protected set; }
        public string Text { get; protected set; }
        public string Gender { get; protected set; }
        public string WebsiteUrl { get; protected set; }
    }
}