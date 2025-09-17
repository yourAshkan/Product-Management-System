using MediatR;
using ProductApp.Domain.Categories.Entities;

namespace ProductApp.Application.Queries.Categories
{
    public class GetAllCategoryiesQuery : IRequest<List<Category>>
    {
    }
}
