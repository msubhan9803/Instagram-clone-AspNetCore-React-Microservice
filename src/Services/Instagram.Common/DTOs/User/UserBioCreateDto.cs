using System;
using Microsoft.AspNetCore.Http;

namespace Instagram.Common.DTOs.User
{
    public class UserBioCreateDto
    {
        public IFormFile ProfileImage { get; set; }
        public string Text { get; set; }
        public string Gender { get; set; }
        public string WebsiteUrl { get; set; }
    }
}