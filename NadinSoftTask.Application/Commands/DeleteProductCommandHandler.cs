using MediatR;
using NadinSoftTask.Application.Interfaces;

namespace NadinSoftTask.Application.Commands;

public class DeleteProductCommandHandler(IProductRepository _repo) : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var prodcut = await _repo.GetByIdAsync(request.ProductId);
            if (prodcut == null)
                throw new Exception("Product not found");

            if (!prodcut.CanModify(request.CurrentUserId))
                throw new Exception("You are not allowed to modify this product!");


            await _repo.DeleteAsync(prodcut);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
