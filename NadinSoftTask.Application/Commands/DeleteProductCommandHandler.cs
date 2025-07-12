using MediatR;
using NadinSoftTask.Application.Interfaces;

namespace NadinSoftTask.Application.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repo;
    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _repo = productRepository;
    }
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var prodcut = await _repo.GetByIdAsync(request.ProductId);
        if (prodcut == null)
            throw new Exception("Product not found");

        if (!prodcut.CanModify(request.CurrentUserId))
            throw new Exception("You are not allowed to modify this product!");


        await _repo.DeleteAsync(prodcut);
        return true;
    }
}
