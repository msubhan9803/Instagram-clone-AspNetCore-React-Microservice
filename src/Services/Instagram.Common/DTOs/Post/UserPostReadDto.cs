using System;

namespace Instagram.Common.DTOs.Post
{
    public class UserPostReadDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Caption { get; set; }
        public Guid FileId { get; set; }
        public string FileType { get; set; }
        public int NumOfLikes { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserPostReadDto(Guid id, Guid userId, string userName, 
            string caption, Guid fileId, string fileType, int numOfLikes, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            UserName = userName;
            Caption = caption;
            FileId = fileId;
            FileType = fileType;
            NumOfLikes = numOfLikes;
            CreatedAt = createdAt;
        }
    }
}