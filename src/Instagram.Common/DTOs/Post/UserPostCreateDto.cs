using System;

namespace Instagram.Common.DTOs.Post
{
    public class UserPostCreateDto
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}