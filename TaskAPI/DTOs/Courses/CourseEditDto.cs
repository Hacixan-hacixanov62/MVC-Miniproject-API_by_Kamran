using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;
using TaskAPI.Models;

namespace TaskAPI.DTOs.Courses
{
    public class CourseEditDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public ICollection<CourseImage>? CourseImages { get; set; }
        public List<IFormFile>? UploadImages { get; set; }
    }

    public class CourseEditDtoValidator : AbstractValidator<CourseEditDto>
    {
        public CourseEditDtoValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name cannot exceed 50 characters");

            RuleFor(m => m.Description)
                .NotEmpty()
                .WithMessage("Description is required");

            RuleFor(m => m.Price)
                .NotEmpty()
                .WithMessage("Price is required");

            RuleFor(m => m.Rating)
                .NotEmpty()
                .WithMessage("Rating is required")
                .LessThanOrEqualTo(5)
                .WithMessage("Rating cannot exceed 5");

            RuleFor(m => m.CategoryId)
                .NotEmpty()
                .WithMessage("Category id is required");

            RuleFor(m => m.InstructorId)
                .NotEmpty()
                .WithMessage("Instructor id is required");

            RuleFor(m => m.StartDate)
                .NotEmpty()
                .WithMessage("Start date is required")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Start date must be greater than today's date");

            RuleFor(m => m.EndDate)
                .NotEmpty()
                .WithMessage("End date is required")
                .GreaterThan(m => m.StartDate)
                .WithMessage("End date must be greater than start date");

            RuleFor(m => m.UploadImages)
                .NotEmpty()
                .WithMessage("Image is required")
                .When(m => m.UploadImages is not null)
                .ForEach(uploadImages => uploadImages
                    .Must(item => item.ContentType.Contains("image/"))
                    .WithMessage("File must be image type")
                    .Must(item => item.Length / 1024 < 500)
                    .WithMessage("Image size cannot exceed 500Kb"))
                .When(m => m.UploadImages is not null);
        }
    }
}
