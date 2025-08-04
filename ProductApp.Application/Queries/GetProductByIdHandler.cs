using MediatR;
using ProductApp.Domain.Products.Contracts;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Queries;

public class GetProductByIdHandler(IProductRepository _repo) : IRequestHandler<GetProductById, Product>
{
    public async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        try
        {
            return await _repo.GetByIdAsync(request.ProductId);
        }
        catch
        {
            throw new Exception("Error!");
        }
    }
}
