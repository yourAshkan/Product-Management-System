using MediatR;

namespace NadinSoftTask.Application.Commands;

public class EditProductCommnad : IRequest<bool>
{
    public int ProductId { get; init; }
    public string NewTitle { get; init; }
    public DateTime NewProduceDate { get; init; }
    public string NewManufactureEmail { get; init; }
    public string NewManufacturePhone { get; init; }
    public int CurrentUserID { get; set; }
}
