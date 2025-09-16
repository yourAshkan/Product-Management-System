using MediatR;
using ProductApp.Domain.Products.Contracts;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Queries
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
            catch
            {
                throw new Exception("Error!");
            }
        }
    }
}
