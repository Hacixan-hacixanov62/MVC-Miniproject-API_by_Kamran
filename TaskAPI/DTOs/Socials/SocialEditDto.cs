using FluentValidation;

namespace TaskAPI.DTOs.Socials
{
    public class SocialEditDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }

    public class SocialEditDtoValidator : AbstractValidator<SocialEditDto>
    {
        public SocialEditDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot exceed 50 characters");

            RuleFor(m => m.Icon)
                .NotEmpty()
                .WithMessage("Icon is required");
        }
    }
}
