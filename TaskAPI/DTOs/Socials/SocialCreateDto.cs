using FluentValidation;

namespace TaskAPI.DTOs.Socials
{
    public class SocialCreateDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }

    public class SocialCreateDtoValidator : AbstractValidator<SocialCreateDto>
    {
        public SocialCreateDtoValidator()
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
