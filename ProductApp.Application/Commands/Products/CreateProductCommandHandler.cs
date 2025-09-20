using MediatR;
using ProductApp.Domain.Products.Contract;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Commands.Products;

public class CreateProductCommandHandler(IProductRepository _repo) : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = new Product(
                request.Title,
                request.ProduceDate,
                request.ManufactureEmail,
                request.ManufacturePhone,
                request.UserID,
                request.CategoryId,
                request.Price,
                request.Count);

            await _repo.AddAsync(product);
            return product;
        }
        catch
        {
            throw new Exception("Error!");
        }
    }
}
