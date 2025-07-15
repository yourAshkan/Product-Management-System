using MediatR;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Domain.Products.Entities;

namespace NadinSoftTask.Application.Queries;

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
