using MediatR;
using NadinSoftTask.Domain.Products.Entities;

namespace NadinSoftTask.Application.Commands;

public class CreateProductCommand(string title,DateTime produceDate,string manufatureEmail,string manufacturePhone,int userID) : IRequest<Product>
{
    public string Title { get; init; } = title;
    public DateTime ProduceDate { get; init; } = produceDate;
    public string ManufactureEmail { get; init; } = manufatureEmail;
    public string ManufacturePhone { get; init; } = manufacturePhone;
    public int UserID { get; init; } = userID;
}
