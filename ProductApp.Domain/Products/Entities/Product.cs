using ProductApp.Domain.Users.Entities;

namespace ProductApp.Domain.Products.Entities;

public class Product(string title, DateTime produceDate, string manufactureEmail, string manufacturePhone, int userId, int categoryId)
{
    public int Id { get; set; }
    public string Title { get; private set; } = title;
    public DateTime ProduceDate { get; private set; } = produceDate;
    public string ManufactureEmail { get; private set; } = manufactureEmail;
    public string ManufacturePhone { get; private set; } = manufacturePhone;
    public bool IsAvailable { get; private set; } = true;
    public int UserId { get; set; } = userId;
    public User User { get; set; }
    public int CategoryId { get; set; } = categoryId;
    public Category Category { get; set; }


    public bool CanModify(int currentUserId)
    {
       return UserId == currentUserId;
    }
    public void MarkAsUnAvailable()
    {
        IsAvailable = false;
    }
    public void Edit(string newTitle,DateTime newProduceDate,string newManufactureEmail,string newManufacturePhone, int categoryId)
    {
        Title = newTitle;
        ProduceDate = newProduceDate;
        ManufactureEmail = newManufactureEmail;
        ManufacturePhone = newManufacturePhone;
        CategoryId = categoryId;
    }
    public void AssignCategory(int categoryId)
    {
        CategoryId = categoryId;
    }
}

