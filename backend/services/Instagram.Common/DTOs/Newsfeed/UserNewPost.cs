using System;

namespace Instagram.Common.DTOs.Post
{
    public class UserNewPost
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Caption { get; set; }
        public string FileId { get; set; }
        public string FileType { get; set; }
        public string CreatedAt { get; set; }

        public UserNewPost(string id, string userId, string caption, string fileId, string fileType, string createdAt)
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