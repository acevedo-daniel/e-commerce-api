namespace e_commerce_api.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string? AltText { get; set; }
        public int Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}