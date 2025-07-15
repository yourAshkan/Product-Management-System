using MediatR;
using NadinSoftTask.Application.Interfaces;
using NadinSoftTask.Domain.Products.Entities;

namespace NadinSoftTask.Application.Queries;

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
