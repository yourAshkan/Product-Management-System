using MediatR;
using NadinSoftTask.Domain.Products;

namespace NadinSoftTask.Application.Queries;

public class GetAllProductsQuery : IRequest<List<Product>>
{

}
