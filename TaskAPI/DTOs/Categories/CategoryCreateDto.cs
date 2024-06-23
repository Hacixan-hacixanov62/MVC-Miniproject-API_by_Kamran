using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace TaskAPI.DTOs.Categories
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }

    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(m => m.UploadImage)
                .NotEmpty()
                .WithMessage("Image is required");

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
