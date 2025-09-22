using ProductApp.Domain.Products.Entities;

namespace ProductApp.Domain.Cart.Entities;

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public ShoppingCart Cart { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quentity { get; set; }
    public decimal TotalPrice => Product.Price.HasValue ? Product.Price.Value * Quentity : 0;
}
