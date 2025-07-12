using MediatR;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Domain.Products;

namespace NadinSoftTask.Application.Queries;

public class GetProductByIdHandler : IRequestHandler<GetProductById, Product>
{
    private readonly IProductRepository _repo;
    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _repo = productRepository;
    }
    public async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.ProductId);
    }
}
