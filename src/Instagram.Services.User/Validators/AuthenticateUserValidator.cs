using System.Linq;
using FluentValidation;
using Instagram.Common.DTOs.User;

namespace Instagram.Common.Validators
{
    public class AuthenticateUserValidator : AbstractValidator<AuthenticateUser>
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