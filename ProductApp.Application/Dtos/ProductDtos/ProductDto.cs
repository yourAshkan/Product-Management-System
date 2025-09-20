namespace ProductApp.Application.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }
        public bool IsAvailabe { get; set; }
        public int UserId { get; set; }
        public string CategoryName { get; set; }
    }
}
