using FluentValidation;

namespace TaskAPI.DTOs.Settings
{
    public class SettingEditDto
    {
        public string Value { get; set; }
    }

    public class SettingEditDtoValidator : AbstractValidator<SettingEditDto>
    {
        public SettingEditDtoValidator()
        {
            RuleFor(m => m.Value)
                .NotEmpty()
                .WithMessage("Value is required")
                .MaximumLength(50)
                .WithMessage("Value cannot exceed 50 characters");
        }
    }
}
