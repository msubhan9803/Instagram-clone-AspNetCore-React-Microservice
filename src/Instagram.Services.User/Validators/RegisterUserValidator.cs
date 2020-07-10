using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Instagram.Common.DTOs.User;
using Instagram.Services.User.Data;
using Instagram.Services.User.Domain.Models;

namespace Instagram.Common.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUser>
    {        
        public RegisterUserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Matches("[A-Z]").WithMessage(ErrorMessages.PasswordUppercaseLetter)
                .Matches("[a-z]").WithMessage(ErrorMessages.PasswordLowercaseLetter)
                .Matches("[0-9]").WithMessage(ErrorMessages.PasswordDigit)
                .Matches("[^a-zA-Z0-9]").WithMessage(ErrorMessages.PasswordSpecialCharacter);
                .Matches("[a-z0-9._]")
                .WithMessage("Username can only contain 'a-z', '0-9', . or _");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Username can only contain 'a-z', '0-9', . or _")
                .Matches("[A-Z]").WithMessage(ErrorMessages.PasswordUppercaseLetter)
                .Matches("[a-z]").WithMessage(ErrorMessages.PasswordLowercaseLetter)
                .Matches("[0-9]").WithMessage(ErrorMessages.PasswordDigit)
                .Matches("[^a-zA-Z0-9]").WithMessage(ErrorMessages.PasswordSpecialCharacter);
                .Matches("[a-z0-9._]")
                .WithMessage("Username can only contain 'a-z', '0-9', . or _");

            // RuleFor(x => x.ConfirmPassword)
            // .Equal(x => x.Password)
            // .WithMessage("Passwords do not match");
        }
    }
}