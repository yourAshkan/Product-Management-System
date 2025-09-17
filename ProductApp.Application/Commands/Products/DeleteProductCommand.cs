using MediatR;

namespace ProductApp.Application.Commands.Products;

public class DeleteProductCommand(int productId,int currentUserID) : IRequest<bool>
{
    public int ProductId { get; init; } = productId;
    public int CurrentUserId { get; init; } = currentUserID;
}
