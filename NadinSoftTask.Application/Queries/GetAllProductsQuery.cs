using MediatR;
using NadinSoftTask.Domain.Products.Entities;

namespace NadinSoftTask.Application.Queries;

public class GetAllProductsQuery : IRequest<List<Product>>
{
}
