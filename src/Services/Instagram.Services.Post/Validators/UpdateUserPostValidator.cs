using FluentValidation;
using Instagram.Common.DTOs.Post;

namespace Instagram.Services.Post.Validators
{
    public class UpdateUserPostValidator : AbstractValidator<UserPostUpdateDto>
    {
        public UpdateUserPostValidator()
        {
            RuleFor(x => x.Caption)
                .NotEmpty().WithMessage("Caption is required.");
        }
    }
}