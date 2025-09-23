using FluentValidation;
using ProductApp.Application.Commands.Categories;

namespace ProductApp.Application.Validators.Categories
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MinimumLength(200).WithMessage("Name cannot exceed 200 characters.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserID must be provided");
        }
    }
}
