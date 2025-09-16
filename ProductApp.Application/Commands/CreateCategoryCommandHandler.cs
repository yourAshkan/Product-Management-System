using MediatR;
using ProductApp.Domain.Products.Contracts;
using ProductApp.Domain.Products.Entities;

namespace ProductApp.Application.Commands
{
    public class CreateCategoryCommandHandler(ICategoryRepository _repo) : IRequestHandler<CreateCategoryCommand, Category>
    {
        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name,request.UserId);
            await _repo.AddAsync(category);

            return category;
        }
    }
}
