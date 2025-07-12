using MediatR;
using NadinSoftTask.Application.Interfaces;

namespace NadinSoftTask.Application.Commands;

public class EditProductCommandHandler : IRequestHandler<EditProductCommnad, bool>
{
    private readonly IProductRepository _repo;
    public EditProductCommandHandler(IProductRepository productRepository)
    {
        _repo = productRepository;
    }
    public async Task<bool> Handle(EditProductCommnad request, CancellationToken cancellationToken)
    {
        var prodcut = await _repo.GetByIdAsync(request.ProductId);
        if (prodcut == null)
            throw new Exception("Product Not found!");

        if (!prodcut.CanModify(request.CurrentUserID))
            throw new Exception("You are not allowed to modify this product!");


        prodcut.Edit(request.NewTitle,
                     request.NewProduceDate,
                     request.NewManufactureEmail,
                     request.NewManufacturePhone);


        return true;
    }
}
