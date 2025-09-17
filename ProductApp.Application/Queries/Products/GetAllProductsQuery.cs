using MediatR;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Queries.Products;

public class GetAllProductsQuery : IRequest<List<Product>>
{
}
