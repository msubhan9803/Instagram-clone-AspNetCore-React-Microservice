using System;

namespace Instagram.Common.Events
{
    public class UserCreated : IEvent
    {
        public Guid UserId { get; }

        protected UserCreated()
        {
        }

        public UserCreated(Guid userId)
        {
            UserId = userId;
        }
    }
}