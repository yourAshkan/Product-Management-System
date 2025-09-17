using MediatR;
using ProductApp.Domain.Products.Entities;
using System.Text.Json.Serialization;

namespace ProductApp.Application.Commands.Products;

[method: JsonConstructor]
public class CreateProductCommand(string title, string manufactureEmail, string manufacturePhone, int userID, int categoryId) : IRequest<Product>
{

    public string Title { get; init; } = title;
    public DateTime ProduceDate { get; init; } = DateTime.Now;
    public string ManufactureEmail { get; init; } = manufactureEmail;
    public string ManufacturePhone { get; init; } = manufacturePhone;
    public bool IsAvailable { get; set; } = true;
    public int UserID { get; set; } = userID;
    public int CategoryId { get; set; } = categoryId;
}
