using System;
using System.Collections.Generic;
using Instagram.Common.DTOs.Post;

namespace Instagram.Common.Events
{
    public class UsersNewPostsFetched : IEvent
    {
        public Guid ParentUserId { get; set; }
        public IEnumerable<UserPostReadDto> Posts { get; set; }

        protected UsersNewPostsFetched()
        {
        }
        
        public UsersNewPostsFetched(Guid parentUserId, IEnumerable<UserPostReadDto> posts)
        {
            ParentUserId = parentUserId;
            Posts = posts;
        }
    }
}