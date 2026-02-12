using ECommerce.Models.Domain.Entities;

namespace ECommerce.Models.DTO.Buyer
{
    public class BuyerOrderResponseDto
    {
        public Guid OrderId { get; set; }
        public decimal OrderValue { get; set; }
        public int ProductCount { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public string DeliveryAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
