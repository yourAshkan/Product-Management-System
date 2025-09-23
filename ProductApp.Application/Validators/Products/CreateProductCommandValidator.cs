using FluentValidation;
using ProductApp.Application.Commands.Products;

namespace ProductApp.Application.Validators.Products
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Name cannot exceed 200 characters.");


            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");


            RuleFor(x => x.ManufacturePhone)
                .NotEmpty().WithMessage("Manufacture phone is required.")
                .Matches(@"^\+?\d{8,15}$").WithMessage("Phone is Invalid!");


            RuleFor(x => x.ManufactureEmail)
                .NotEmpty().WithMessage("Manufacture email is required.")
                .EmailAddress().WithMessage("Email is Invalid!");

            RuleFor(x => x.Count)
                .GreaterThanOrEqualTo(0).WithMessage("Count must be greater than zero.");


            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be provided");

            RuleFor(x => x.UserID)
                .GreaterThan(0).WithMessage("UserID must be provided");
        }
    }
}
