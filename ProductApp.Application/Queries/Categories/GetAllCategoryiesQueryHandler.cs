using AutoMapper;
using MediatR;
using ProductApp.Application.Dtos.CategoryDtos;
using ProductApp.Domain.Categories.Contract;

namespace ProductApp.Application.Queries.Categories
{
    public class GetAllCategoryiesQueryHandler(ICategoryRepository _repo,IMapper _mapper) : IRequestHandler<GetAllCategoryiesQuery, List<CategoryDto>>
    {
        public async Task<List<CategoryDto>> Handle(GetAllCategoryiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _repo.GetAllAsync();
                return _mapper.Map<List<CategoryDto>>(categories);
            }
            catch(Exception ex)
            {
                throw new Exception("Erorr",ex);
            }
        }
    }
}
