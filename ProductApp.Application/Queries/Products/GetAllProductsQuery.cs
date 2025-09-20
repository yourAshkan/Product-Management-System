using MediatR;
using ProductApp.Application.Dtos.ProductDtos;

namespace ProductApp.Application.Queries.Products;

public class GetAllProductsQuery : IRequest<List<ProductDto?>>
{
}
