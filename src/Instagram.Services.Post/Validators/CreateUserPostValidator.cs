using FluentValidation;
using Instagram.Common.DTOs.Post;

namespace Instagram.Services.Post.Validators
{
    public class CreateUserPostValidator : AbstractValidator<UserPostCreateDto>
    {
        public CreateUserPostValidator()
        {
            RuleFor(x => x.Caption)
                .NotEmpty().WithMessage("Type is required.");

            RuleFor(x => x.FileName)
                .NotEmpty().WithMessage("Title is required.");

            RuleFor(x => x.FilePath)
                .NotEmpty().WithMessage("Description is required.");
        }
    }
}