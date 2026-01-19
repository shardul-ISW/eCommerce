using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.Domain
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.CreateVersion7();

        public required Seller Seller { get; set; }

        public required string Sku { get; set; }

        public required string Name { get; set; }

        public required string Price { get; set; }

        public required int Count_in_stock { get; set; }

        public string? Description { get; set; }

        public byte[]? Images { get; set; }

        public required bool IsListed { get; set; }

    }
}
