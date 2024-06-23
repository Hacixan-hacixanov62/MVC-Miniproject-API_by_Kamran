using FluentValidation;

namespace TaskAPI.DTOs.Contacts
{
    public class ContactCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

    public class ContactCreateDtoValidator : AbstractValidator<ContactCreateDto>
    {
        public ContactCreateDtoValidator()
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

            RuleFor(m => m.Subject)
                .NotEmpty()
                .WithMessage("Subject is required")
                .MaximumLength(50)
                .WithMessage("Subject can be max 50 characters");

            RuleFor(m => m.Message)
                .NotEmpty()
                .WithMessage("Message is required");
        }
    }
}
