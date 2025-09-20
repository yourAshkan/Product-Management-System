using ProductApp.Domain.Users.Entities;
using ProductApp.Domain.Categories.Entities;

namespace ProductApp.Domain.Products.Entities;

public class Product
{
    public int Id { get; set; }
    public string Title { get; private set; }
    public DateTime ProduceDate { get; private set; }
    public string ManufactureEmail { get; private set; }
    public string ManufacturePhone { get; private set; }
    //public decimal Price { get; set; }
    //public int Count { get; set; }
    public bool IsAvailable { get; private set; } = true;
    public int? UserId { get; set; } 
    public User User { get; set; }
    public int? CategoryId { get; set; }
    public Category Category { get; set; }

    public Product()
    {
    }

    public Product(string title, DateTime produceDate, string manufactureEmail, string manufacturePhone, int? userId, int? categoryId)
    {
        Title = title;
        ProduceDate = produceDate;
        ManufactureEmail = manufactureEmail;
        ManufacturePhone = manufacturePhone;
        UserId = userId;
        CategoryId = categoryId;
        ProduceDate = DateTime.Now;
    }

    //public int Counter(int count)
    //{
    //    if (count >= 0)
    //        Count += count;

    //}
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

