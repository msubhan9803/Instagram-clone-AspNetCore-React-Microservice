using System.Linq;
using FluentValidation;
using Instagram.Common.DTOs.User;

namespace Instagram.Services.Users.Validators
{
    public class AuthenticateUserValidator : AbstractValidator<UserAuthenticateDto>
    {        
        public AuthenticateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}