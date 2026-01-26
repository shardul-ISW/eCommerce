using ECommerce.Models.Domain.Entities;

namespace ECommerce.Models.DTO.Seller
{
    public class UpdateOrderDto
    {
        public required OrderStatus Status { get; set; }
    }
}
