using System;
using Microsoft.AspNetCore.Http;

namespace Instagram.Common.DTOs.Post
{
    public class UserPostCreateDto
    {
        public string Caption { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}