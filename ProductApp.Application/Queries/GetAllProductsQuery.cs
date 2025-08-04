using MediatR;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Queries;

public class GetAllProductsQuery : IRequest<List<Product>>
{
}
