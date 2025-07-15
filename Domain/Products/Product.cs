using NadinSoftTask.Domain.Users;

namespace NadinSoftTask.Domain.Products;

public class Product
{
    public int Id { get; set; }
    public string Title { get; private set; }
    public DateTime ProduceDate { get; private set; }
    public string ManufactureEmail { get;  set; }
    public string ManufacturePhone { get; set; }
    public bool IsAvailable { get; set; } = true;

    public int UserId { get; set; }
    public User User { get; set; }

    public Product(string title, DateTime produceDate, string manufactureEmail, string manufacturePhone, int userId)
    {
        Title = title;
        ProduceDate = produceDate;
        ManufactureEmail = manufactureEmail;
        ManufacturePhone = manufacturePhone;
        UserId = userId;
    }


    public bool CanModify(int currentUserId)
    {
       return UserId == currentUserId;
    }

    public void MarkAsUnAvailable()
    {
        IsAvailable = false;
    }

    public void Edit(string newTitle,DateTime newProduceDate,string newManufactureEmail,string newManufacturePhone)
    {
        Title = newTitle;
        ProduceDate = newProduceDate;
        ManufactureEmail = newManufactureEmail;
        ManufacturePhone = newManufacturePhone;
    }
}

