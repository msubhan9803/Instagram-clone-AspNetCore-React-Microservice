using System;
using Instagram.Common.Exceptions;
using Instagram.Services.User.Domain.Services;

namespace Instagram.Services.User.Domain.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }

        public User(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new InstagramException("empty_user_email", 
                    "User email can not be empty.");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InstagramException("empty_user_name", 
                    "User name can not be empty.");
            }        
            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            UserName = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new InstagramException("empty_password", 
                    "Password can not be empty.");
            }
            Salt = encrypter.GetSalt();
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => Password.Equals(encrypter.GetHash(password, Salt));
    }
}