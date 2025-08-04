using MediatR;
using ProductApp.Domain.Products.Contracts;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Queries;

public class GetAllProductsQueryHandler(IProductRepository _repo) : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await _repo.GetAllAsync();
            return products;
        }
        catch
        {
            throw new Exception("Error!");
        }
    }
}
