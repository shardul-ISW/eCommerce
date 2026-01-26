namespace ECommerce.Models.DTO.Seller
{
    public class AddProductDto
    {
        public required string Sku { get; set; }
        public required string Name { get; set; }
        public required int CountInStock { get; set; }
        public required decimal Price { get; set; }
        public string? Description { get; set; }
        public byte[]? Images { get; set; }
        public required bool IsListed { get; set; }

    }
}