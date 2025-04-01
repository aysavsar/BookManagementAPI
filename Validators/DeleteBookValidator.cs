using BookManagementAPI.Models.Requests;
using FluentValidation;

namespace BookManagementAPI.Validators
{
    public class DeleteBookValidator : AbstractValidator<GetBookByIdRequest> // Reusing GetBookByIdRequest for delete
    {
        public DeleteBookValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .NotEqual(Guid.Empty).WithMessage("Id cannot be empty");
        }
    }
}