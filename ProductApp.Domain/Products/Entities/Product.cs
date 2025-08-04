using ProductApp.Domain.Users.Entities;

namespace ProductApp.Domain.Products.Entities;

public class Product(string title, DateTime produceDate, string manufactureEmail, string manufacturePhone, int userId)
{
    public int Id { get; set; }
    public string Title { get; private set; } = title;
    public DateTime ProduceDate { get; private set; } = produceDate;
    public string ManufactureEmail { get; private set; } = manufactureEmail;
    public string ManufacturePhone { get; private set; } = manufacturePhone;
    public bool IsAvailable { get; private set; } = true;

    public int UserId { get; private set; } = userId;
    public User User { get; private set; }

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

