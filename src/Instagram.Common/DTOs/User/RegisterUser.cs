using System.ComponentModel.DataAnnotations;

namespace Instagram.Common.DTOs.User
{
    public class RegisterUser
    {
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}