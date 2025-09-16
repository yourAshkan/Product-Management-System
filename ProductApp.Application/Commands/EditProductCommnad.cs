using MediatR;

namespace ProductApp.Application.Commands;

public class EditProductCommnad(int productId, string newTitle, DateTime newProduceDate, string newManufactureEmail, string newManufacturePhone,int currentUserId ,int categoryId) : IRequest<bool>
{
    public int ProductId { get; set; } = productId;
    public string NewTitle { get; init; } = newTitle;
    public DateTime NewProduceDate { get; init; } = newProduceDate;
    public string NewManufactureEmail { get; init; } = newManufactureEmail;
    public string NewManufacturePhone { get; init; } = newManufacturePhone;
    public int CurrentUserId { get; set; } = currentUserId;
    public int CategoryId { get; set; } = categoryId;
}

