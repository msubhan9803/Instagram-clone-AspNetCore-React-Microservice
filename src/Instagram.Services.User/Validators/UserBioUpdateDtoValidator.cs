using FluentValidation;
using Instagram.Common.DTOs.User;

namespace Instagram.Common.Validators
{
    public class UserBioUpdateDtoValidator : AbstractValidator<UserBioUpdateDto>
    {
        public UserBioUpdateDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Type is required.");

            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Title is required.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.WebsiteUrl)
                .NotEmpty().WithMessage("Url is required.");
        }
    }
}