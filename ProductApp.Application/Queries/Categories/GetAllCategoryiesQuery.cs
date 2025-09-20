using MediatR;
using ProductApp.Application.Dtos.CategoryDtos;

namespace ProductApp.Application.Queries.Categories
{
    public class GetAllCategoryiesQuery : IRequest<List<CategoryDto>>
    {
    }
}
