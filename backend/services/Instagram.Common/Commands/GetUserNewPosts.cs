using System;

namespace Instagram.Common.Commands
{
    public class GetUserNewPosts : ICommand
    {
        public Guid ParentUserId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastModified { get; set; }

        protected GetUserNewPosts()
        {
        }

        public GetUserNewPosts(Guid parentUserId, Guid userId, DateTime lastModified)
        {
            ParentUserId = parentUserId;
            UserId = userId;
            LastModified = lastModified;
        }
    }
}