using ECommerce.Data;
using ECommerce.Models.Domain;
using ECommerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Repositories.Implementations
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ECommerceDbContext dbContext;

        public OrdersRepository(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Order>> GetOrdersAsync(
            IReadOnlyCollection<Guid>? orderIds = null, 
            IReadOnlyCollection<Guid>? sellerIds = null, 
            IReadOnlyCollection<Guid>? productIds = null
            )
        {
            IQueryable<Order> query = dbContext.Orders;

            if (orderIds is { Count: > 0 })
                query = query.Where(o => orderIds.Contains(o.Id));

            if (sellerIds is { Count: > 0 })
                query = query.Where(o => sellerIds.Contains(o.SellerId));

            if (productIds is { Count: > 0 })
                query = query.Where(o => productIds.Contains(o.ProductId));

            return await query.ToListAsync();
        }
    }
}
