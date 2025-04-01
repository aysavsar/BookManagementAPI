using BookManagementAPI.Models.Requests;
using FluentValidation;

namespace BookManagementAPI.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookRequest>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .NotEqual(Guid.Empty).WithMessage("Id cannot be empty");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author is required")
                .MaximumLength(50).WithMessage("Author name cannot exceed 50 characters");

            RuleFor(x => x.PublicationYear)
                .InclusiveBetween(1800, DateTime.Now.Year)
                .WithMessage($"Publication year must be between 1800 and {DateTime.Now.Year}");

            RuleFor(x => x.PageCount)
                .GreaterThan(0).WithMessage("Page count must be positive");

            RuleFor(x => x.Isbn)
                .MaximumLength(17).WithMessage("ISBN cannot exceed 17 characters")
                .When(x => !string.IsNullOrEmpty(x.Isbn));
        }
    }
}