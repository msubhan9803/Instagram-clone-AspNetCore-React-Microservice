using System.Linq;
using FluentValidation;
using Instagram.Common.DTOs.User;

namespace Instagram.Common.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUser>
    {        
        public RegisterUserValidator()
        {
            // Instagram actual username regex: (?:^|[^\w])(?:@)([A-Za-z0-9_](?:(?:[A-Za-z0-9_]|(?:\.(?!\.))){0,28}(?:[A-Za-z0-9_]))?)
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Matches("[A-Z]").WithMessage("Username must contain at least one uppercase or capital letter")
                .Matches("[a-z]").WithMessage("Username must contain at least one lowercase")
                .Matches("[0-9]").WithMessage("Username must contain at least one digit");
                
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Length(8, 12).WithMessage("Password must be between 8 and 12 characters")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase or capital letter")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit");

            RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm Password field is required.")
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match");
        }
    }
}