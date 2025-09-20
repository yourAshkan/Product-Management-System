using MediatR;
using ProductApp.Domain.Products.Contract;
using ProductApp.Application.Dtos.ProductDtos;
using AutoMapper;

namespace ProductApp.Application.Queries.Products;

public class GetProductByIdHandler(IProductRepository _repo,IMapper _mapper) : IRequestHandler<GetProductById, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductById request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _repo.GetByIdAsync(request.ProductId);
            return _mapper.Map<ProductDto?>(product);
        }
        catch(Exception ex)
        {
            throw new Exception("Error!",ex);
        }
    }
}
