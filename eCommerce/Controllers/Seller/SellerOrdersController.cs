
using AutoMapper;
using ECommerce.Models.Domain;
using ECommerce.Models.DTO.Seller;
using ECommerce.Repositories.Interfaces;
using ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers.Seller
{
    [ApiController]
    [Route("seller/orders")]
    [Authorize(Roles = "Seller")]
    public class OrdersController : ControllerBase
    {
        private readonly Guid sellerId;
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

        public OrdersController(ICurrentUser currentUser, IOrdersRepository ordersRepository, IMapper mapper)
        {
            sellerId = currentUser.UserId;
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSellerOrders()
        {
            List<Order> orders = await ordersRepository.GetOrdersAsync(sellerIds: [sellerId]);

            var sellerOrderResponseDtos = new List<SellerOrderResponseDto>();

            foreach (Order o in orders)
                sellerOrderResponseDtos.Add(mapper.Map<SellerOrderResponseDto>(o));

            return Ok(sellerOrderResponseDtos);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetSellerOrderByOrderID([FromRoute] Guid orderId)
        {
            Order? order = (await ordersRepository.GetOrdersAsync(orderIds: [orderId], sellerIds: [sellerId])).FirstOrDefault();

            if (order is null) return NotFound();

            var sellerOrderResponseDto = mapper.Map<SellerOrderResponseDto>(order);
            return Ok(sellerOrderResponseDto);
        }

        [HttpPatch("{orderId}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] Guid orderId, [FromBody] UpdateOrderDto Dto)
        {
            Order? order = (await ordersRepository.GetOrdersAsync(orderIds: [orderId], sellerIds: [sellerId])).FirstOrDefault();

            if (order is null) return NotFound();

            // TODO: Transaction rollback if seller cancels order.

            order.Status = Dto.NewStatus;

            return Ok();
        }
    }
}
