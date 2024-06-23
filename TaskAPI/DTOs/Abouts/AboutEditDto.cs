using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace TaskAPI.DTOs.Abouts
{
    public class AboutEditDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile? UploadImage { get; set; }
    }

    public class AboutEditDtoValidator : AbstractValidator<AboutEditDto>
    {
        public AboutEditDtoValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Title is required");

            RuleFor(m => m.Description)
                .NotEmpty()
                .WithMessage("Description is required");

            RuleFor(m => m.UploadImage)
                .Must(p => p.ContentType.Contains("image/"))
                .When(m => m.UploadImage is not null)
                .WithMessage("File must be image type")
                .Must(p => p.Length / 1024 < 500)
                .When(m => m.UploadImage is not null)
                .WithMessage("Image size cannot exceed 500Kb");
        }
    }
}
