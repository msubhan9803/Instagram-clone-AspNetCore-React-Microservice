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

        public UserPostReadDto(Guid id, Guid userId, string caption, Guid fileId, string fileType, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Caption = caption;
            FileId = fileId;
            FileType = fileType;
            CreatedAt = createdAt;
        }
    }
}