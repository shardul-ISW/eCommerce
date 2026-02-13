namespace ECommerce.Models.DTO.Seller
{
    public class UpdateProductDto
    {
        public string? Sku { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsListed { get; set; }
    }
}
