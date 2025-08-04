using MediatR;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Queries;

public class GetProductById(int productId) : IRequest<Product>
{
    public int ProductId { get; set; } = productId;
}
