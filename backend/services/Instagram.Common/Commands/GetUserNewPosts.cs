using System;

namespace Instagram.Common.Commands
{
    public class GetUserNewPosts : ICommand
    {
        public Guid UserId { get; set; }
        public DateTime LastModified { get; set; }

        protected GetUserNewPosts()
        {
        }

        public GetUserNewPosts(Guid userId, DateTime lastModified)
        {
            UserId = userId;
            LastModified = lastModified;
        }
    }
}