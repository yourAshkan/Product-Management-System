using MediatR;
using NadinSoftTask.Domain.Products.Entities;

namespace NadinSoftTask.Application.Queries;

public class GetProductById(int productId) : IRequest<Product>
{
    public int ProductId { get; set; } = productId;
}
