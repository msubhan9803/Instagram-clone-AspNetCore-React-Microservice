using System;

namespace Instagram.Common.DTOs.Post
{
    public class UserPostUpdateDto
    {
        public Guid UserId { get; protected set; }
        public string Type { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Url { get; protected set; }
    }
}