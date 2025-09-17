using MediatR;

namespace ProductApp.Application.Commands.Categories
{
    public class DeleteCategoryCommand(int categoryId,int currentUserId) : IRequest<bool>
    {
        public int CategoryId { get; init; } = categoryId;
        public int CurrentUserId { get; init; } = currentUserId;
    }
}
