using MediatR;
using NadinSoftTask.Domain.Products;

namespace NadinSoftTask.Application.Commands;

public class CreateProductCommand : IRequest<Product>
{
    public string Title { get; init; }
    public DateTime ProduceDate { get; init; }
    public string ManufactureEmail { get; init; }
    public string ManufacturePhone { get; init; }
    public int UserID { get; init; }
}
