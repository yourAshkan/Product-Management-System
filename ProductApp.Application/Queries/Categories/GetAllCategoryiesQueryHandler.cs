using MediatR;
using ProductApp.Domain.Categories.Contract;
using ProductApp.Domain.Categories.Entities;

namespace ProductApp.Application.Queries.Categories
{
    public class GetAllCategoryiesQueryHandler(ICategoryRepository _repo) : IRequestHandler<GetAllCategoryiesQuery, List<Category>>
    {
        public async Task<List<Category>> Handle(GetAllCategoryiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _repo.GetAllAsync();
                return categories;
            }
            catch(Exception ex)
            {
                throw new Exception("Erorr",ex);
            }
        }
    }
}
