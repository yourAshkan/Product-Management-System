using ProductApp.Domain.Products.Entities;

namespace ProductApp.Domain.Categories.Entities
{
    public class Category(string name,int userId)
    {
        public int Id { get; set; }
        public string Name { get; private set; } = name;
        public int UserId { get; private set; } = userId;
        public bool IsDeleted { get; set; } = false;
        public List<Product> Products { get; private set; } = new List<Product>();

        
        public void SoftDeleted()
        {
            IsDeleted = true;
        }
        public bool CanModify(int currentUserId)
        {
            return UserId == currentUserId;
        }
        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            Products.Add(product);
        }
        public void Edit(string newName)
        {
            Name = newName;
        }
    }
}
