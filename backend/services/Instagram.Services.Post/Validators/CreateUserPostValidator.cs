using FluentValidation;
using Instagram.Common.DTOs.Post;

namespace Instagram.Services.Post.Validators
{
    public class CreateUserPostValidator : AbstractValidator<UserPostCreateDto>
    {
        public CreateUserPostValidator()
        {
            RuleFor(x => x.Caption)
                .NotEmpty().WithMessage("Caption is required.");

            RuleFor(x => x.File)
                .NotEmpty().WithMessage("File is required.");
        }
    }
}