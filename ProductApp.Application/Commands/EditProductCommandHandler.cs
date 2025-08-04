using MediatR;
using ProductApp.Domain.Products.Contracts;

namespace ProductApp.Application.Commands;

public class EditProductCommandHandler(IProductRepository _repo) : IRequestHandler<EditProductCommnad, bool>
{
    public async Task<bool> Handle(EditProductCommnad request, CancellationToken cancellationToken)
    {
        try
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
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}
