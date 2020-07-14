using System;

namespace Instagram.Common.DTOs.Post
{
    public class UserPostUpdateDto
    {
        public Guid UserId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}