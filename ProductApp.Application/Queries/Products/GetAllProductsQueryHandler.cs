using MediatR;
using ProductApp.Domain.Products.Contract;
using ProductApp.Application.Dtos.ProductDtos;
using AutoMapper;

namespace ProductApp.Application.Queries.Products;

public class GetAllProductsQueryHandler(IProductRepository _repo,IMapper _mapper) : IRequestHandler<GetAllProductsQuery, List<ProductDto?>>
{
    public async Task<List<ProductDto?>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<List<ProductDto?>>(products);
        }
        catch(Exception ex)
        {
            throw new Exception("Error!",ex);
        }
    }
}
