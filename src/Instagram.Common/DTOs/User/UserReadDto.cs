using System;

namespace Instagram.Common.DTOs.User
{
    public class UserReadDto
    {
        public Guid Id { get; protected set; }
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
    }
}