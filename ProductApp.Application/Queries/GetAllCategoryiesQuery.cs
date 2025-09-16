using MediatR;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Queries
{
    public class GetAllCategoryiesQuery : IRequest<List<Category>>
    {
    }
}
