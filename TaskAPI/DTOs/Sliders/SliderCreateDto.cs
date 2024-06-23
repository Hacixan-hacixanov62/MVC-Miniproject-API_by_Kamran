using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace TaskAPI.DTOs.Sliders
{
    public class SliderCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }

    public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDto>
    {
        public SliderCreateDtoValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(50)
                .WithMessage("Title can be max 50 characters");

            RuleFor(m => m.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(200)
                .WithMessage("Description can be max 200 characters");

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
