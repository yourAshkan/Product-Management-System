using ProductApp.Domain.Users.Entities;

namespace ProductApp.Domain.Cart.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<CartItem> Items { get; set; } = new();

    public decimal TotalPrice => Items.Sum(x=>x.TotalPrice);
}
