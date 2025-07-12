using MediatR;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Domain.Products;

namespace NadinSoftTask.Application.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly IProductRepository _repo;
    public GetAllProductsQueryHandler(IProductRepository productRepository)
    {
        _repo = productRepository;  
    }
    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repo.GetAllAsync();
        return products;
    }
}
