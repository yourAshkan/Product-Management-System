using MediatR;
using ProductApp.Domain.Categories.Contract;
using ProductApp.Domain.Categories.Entities;

namespace ProductApp.Application.Commands.Categories
{
    public class CreateCategoryCommandHandler(ICategoryRepository _repo) : IRequestHandler<CreateCategoryCommand, Category>
    {
        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categories = new Category(request.Name,request.UserId);
            await _repo.AddAsync(categories);

            return categories;
        }
    }
}
