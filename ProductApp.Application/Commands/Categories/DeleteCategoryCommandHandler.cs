using MediatR;
using ProductApp.Domain.Categories.Contract;

namespace ProductApp.Application.Commands.Categories;

public class DeleteCategoryCommandHandler(ICategoryRepository _repo) : IRequestHandler<DeleteCategoryCommand, bool>
{
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _repo.GetByIdAsync(request.CategoryId);
            if (category == null)
                throw new Exception("Category Not Found!");

            if (!category.CanModify(request.CurrentUserId))
                throw new Exception("You are not allowed to modify this category!");

            await _repo.SoftDeleteAsync(request.CategoryId);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
