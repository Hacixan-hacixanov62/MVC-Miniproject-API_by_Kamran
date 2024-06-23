using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace TaskAPI.DTOs.Categories
{
    public class CategoryEditDto
    {
        public string Name { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile? UploadImage { get; set; }
    }

    public class CategoryEditDtoValidator : AbstractValidator<CategoryEditDto>
    {
        public CategoryEditDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required");

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
