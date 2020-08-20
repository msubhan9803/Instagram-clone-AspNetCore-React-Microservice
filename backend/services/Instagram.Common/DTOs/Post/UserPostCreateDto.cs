using System;
using Microsoft.AspNetCore.Http;

namespace Instagram.Common.DTOs.Post
{
    public class UserPostCreateDto
    {
        public string Caption { get; set; }
        public IFormFile File { get; set; }
    }
}