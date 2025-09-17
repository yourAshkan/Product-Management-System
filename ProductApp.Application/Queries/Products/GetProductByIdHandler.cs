using MediatR;
using ProductApp.Domain.Products.Entities;
using ProductApp.Domain.Products.Contract;

namespace ProductApp.Application.Queries.Products;

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
