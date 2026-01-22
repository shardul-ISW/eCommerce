using AutoMapper;
using ECommerce.Models.Domain;
using ECommerce.Models.DTO.Seller;

namespace ECommerce.Mappings
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, SellerOrderResponseDto>()
                .ForMember(d => d.OrderId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.OrderValue, o => o.MapFrom(s => s.Transaction.Amount))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name))
                .ForMember(d => d.ProductSku, o => o.MapFrom(s => s.Product.Sku))
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId))
                .ForMember(d => d.ProductCount, o => o.MapFrom(s => s.Count))
                .ForMember(d => d.DeliveryAddress, o => o.MapFrom(s => s.Address));
        }
    }
}
