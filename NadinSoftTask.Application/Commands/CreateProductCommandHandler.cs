using MediatR;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Domain.Products.Entities;

namespace NadinSoftTask.Application.Commands;

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
