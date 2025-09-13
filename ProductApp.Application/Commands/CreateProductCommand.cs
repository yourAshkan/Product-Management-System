using MediatR;
using ProductApp.Domain.Products.Entities;
using System.Text.Json.Serialization;

namespace ProductApp.Application.Commands;

public class CreateProductCommand : IRequest<Product>
{

    public string Title { get; init; }
    public DateTime ProduceDate { get; init; }
    public string ManufactureEmail { get; init; }
    public string ManufacturePhone { get; init; }
    public bool IsAvailable { get; set; }
    public int UserID { get; set; }

    [JsonConstructor]
    public CreateProductCommand(string title, string manufactureEmail, string manufacturePhone, int userID)
    {
        Title = title;
        ProduceDate = DateTime.Now;
        ManufactureEmail = manufactureEmail;
        ManufacturePhone = manufacturePhone;
        IsAvailable = true;
        UserID = userID;
    }

}
