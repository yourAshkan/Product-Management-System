using MediatR;
using ProductApp.Domain.Products.Entities;
using System.Text.Json.Serialization;

namespace ProductApp.Application.Commands.Products;

[method: JsonConstructor]
public class CreateProductCommand(string title, string manufactureEmail, string manufacturePhone,
    int userID, int categoryId, decimal price, int count) : IRequest<Product>
{

    public string Title { get; init; } = title;
    public DateTime ProduceDate { get; init; } = DateTime.Now;
    public string ManufactureEmail { get; init; } = manufactureEmail;
    public string ManufacturePhone { get; init; } = manufacturePhone;
    public decimal Price { get; init; } = price;
    public int Count { get; init; } = count;
    public bool IsAvailable { get; set; } = count > 0;
    public int UserID { get; private set; } = userID;
    public int CategoryId { get; init; } = categoryId;

    public void SetUserId(int userId) => UserID = userId; 
}
