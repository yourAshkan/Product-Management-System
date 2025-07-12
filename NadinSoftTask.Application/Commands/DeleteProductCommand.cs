using MediatR;

namespace NadinSoftTask.Application.Commands;

public class DeleteProductCommand : IRequest<bool>
{
    public int ProductId { get; init; }
    public int CurrentUserId { get; init; }
}
