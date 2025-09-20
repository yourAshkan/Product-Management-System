using MediatR;
using ProductApp.Application.Dtos.ProductDtos;

namespace ProductApp.Application.Queries.Products;

public class GetProductById(int productId) : IRequest<ProductDto?>
{
    public int ProductId { get; set; } = productId;
}
