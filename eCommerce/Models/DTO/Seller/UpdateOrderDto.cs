using ECommerce.Models.Domain;

namespace ECommerce.Models.DTO.Seller
{
    public class UpdateOrderDto
    {
        public required OrderStatus NewStatus { get; set; }
    }
}
