using MediatR;
using ProductApp.Domain.Products.Entities;
using ProductApp.Domain.Products.Contract;

namespace ProductApp.Application.Queries.Products;

public class GetAllProductsQueryHandler(IProductRepository _repo) : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await _repo.GetAllAsync();
            return products;
        }
        catch(Exception ex)
        {
            throw new Exception("Error!",ex);
        }
    }
}
