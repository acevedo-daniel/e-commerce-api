using e_commerce_api.DTOs.ProductCategories;
using e_commerce_api.DTOs.ProductImages;

namespace e_commerce_api.DTOs.Product
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public ProducCategoryResponseDto? Category { get; set; }
        public List<ProductImageResponseDto> Images { get; set; } = [];
    }
}