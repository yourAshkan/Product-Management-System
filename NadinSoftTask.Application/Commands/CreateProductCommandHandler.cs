using MediatR;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Domain.Products;

namespace NadinSoftTask.Application.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository _repo;
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _repo = productRepository;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
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
}
