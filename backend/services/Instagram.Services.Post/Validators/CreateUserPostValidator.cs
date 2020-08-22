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

            RuleFor(x => x.File.FileName)
                .NotEmpty().WithMessage("File is required.")
                .Matches(@"(.*?)\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G)|(m|M)(o|O)(v|V)|(a|A)(v|V)(i|I)|(w|W)(m|M)(v|V)|(f|F)(l|L)(v|V)|3(g|G)(p|P)|(m|M)(p|P)4|(m|M)(p|P)(g|G))$")
                .WithMessage("File type not supported");
        }
    }
}