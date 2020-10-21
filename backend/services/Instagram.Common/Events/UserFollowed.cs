using System;

namespace Instagram.Common.Events
{
    public class UserFollowed : IEvent
    {
        public Guid UserId { get; }
        public Guid FollowedUserId { get; }

        protected UserFollowed()
        {
        }

        public UserFollowed(Guid userId, Guid followedUserId)
        {
            UserId = userId;
            FollowedUserId = followedUserId;
        }
    }
}