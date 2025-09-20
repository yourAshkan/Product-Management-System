namespace ProductApp.Application.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public bool IsAvailable { get; set; }
        public int UserId { get; set; }
        public string CategoryName { get; set; }

        public string PriceFormated => Price.ToString("#,##0T");
    }
}
