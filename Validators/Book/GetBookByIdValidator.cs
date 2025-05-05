using BookManagementAPI.Models.Requests;
using FluentValidation;

namespace BookManagementAPI.Validators
{
    public class GetBookByIdValidator : AbstractValidator<GetBookByIdRequest>
    {
        public GetBookByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .NotEqual(Guid.Empty).WithMessage("Id cannot be empty");
        }
    }
}