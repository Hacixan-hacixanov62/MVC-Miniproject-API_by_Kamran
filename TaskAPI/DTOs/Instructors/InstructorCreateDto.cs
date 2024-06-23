using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace TaskAPI.DTOs.Instructors
{
    public class InstructorCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Field { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }

    public class InstructorCreateDtoValidator : AbstractValidator<InstructorCreateDto>
    {
        public InstructorCreateDtoValidator()
        {
            RuleFor(m => m.FullName)
                .NotEmpty()
                .WithMessage("Full name is required")
                .Matches(@"^(?i)[a-z]+[\ -].*[a-z]$")
                .WithMessage("Full name format is wrong")
                .MaximumLength(50)
                .WithMessage("Full name can be max 50 characters");

            RuleFor(m => m.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is invalid")
                .MaximumLength(50)
                .WithMessage("Email can be max 50 characters");

            RuleFor(m => m.Address)
                .NotEmpty()
                .WithMessage("Address is required")
                .MaximumLength(100)
                .WithMessage("Address can be max 100 characters");

            RuleFor(m => m.Phone)
                .NotEmpty()
                .WithMessage("Phone is required")
                .MaximumLength(50)
                .WithMessage("Phone can be max 50 characters");

            RuleFor(m => m.Field)
                .NotEmpty()
                .WithMessage("Field is required")
                .MaximumLength(50)
                .WithMessage("Field can be max 50 characters");

            RuleFor(m => m.UploadImage)
                .NotNull()
                .WithMessage("Image is required")
                .Must(p => p.ContentType.Contains("image/"))
                .When(m => m.UploadImage is not null)
                .WithMessage("File must be image type")
                .Must(p => p.Length / 1024 < 500)
                .WithMessage("Image size cannot exceed 500Kb")
                .When(m => m.UploadImage is not null);
        }
    }
}
