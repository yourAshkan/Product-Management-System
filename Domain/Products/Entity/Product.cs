using NadinSoftTask.Domain.Users.Entity;

namespace NadinSoftTask.Domain.Products.Entity;

public class Product
{
    public int Id { get; set; }
    public string Title { get; private set; }
    public DateTime ProduceDate { get; private set; }
    public string ManufactureEmail { get; set; }
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
}

