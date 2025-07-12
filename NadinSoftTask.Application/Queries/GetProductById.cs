using MediatR;
using NadinSoftTask.Domain.Products;

namespace NadinSoftTask.Application.Queries;

public class GetProductById : IRequest<Product>
{
    public int ProductId { get; set; }

    public GetProductById(int productId)
    {
        ProductId = productId;
    }
}
