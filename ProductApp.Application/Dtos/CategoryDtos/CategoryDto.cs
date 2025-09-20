using ProductApp.Application.Dtos.ProductDtos;

namespace ProductApp.Application.Dtos.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public List<string> ProductNames { get; set; }
    }
}
