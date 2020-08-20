using System;

namespace Instagram.Common.DTOs.Post
{
    public class UserPostReadDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Caption { get; set; }
        public Guid FileId { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}