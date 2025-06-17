namespace e_commerce_api.DTOs.ProductImages
{
    public class ProductImageResponseDto
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string? AltText { get; set; }
        public int Order { get; set; }
    }
}