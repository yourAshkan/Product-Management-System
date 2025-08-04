using MediatR;
using ProductApp.Domain.Products.Contracts;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Commands;

public class CreateProductCommandHandler(IProductRepository _repo) : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = new Product(
                request.Title,
                request.ProduceDate,
                request.ManufacturePhone,
                request.ManufacturePhone,
                request.UserID);
    
            await _repo.AddAsync(product);
            return product;
        }
        catch
        {
            throw new Exception("Error!");
        }
    }
}
