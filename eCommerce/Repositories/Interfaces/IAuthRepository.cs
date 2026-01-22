using ECommerce.Models.Domain;

namespace ECommerce.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task CreateBuyerAsync(Buyer buyer);
        Task CreateSellerAsync(Seller seller);
        Task<Buyer?> GetBuyerIfValidCredentialsAsync(string email, string password);
        Task<Seller?> GetSellerIfValidCredentialsAsync(string email, string password);
        string GenerateJWT(string userId, string email, string name, string role);
    }
}
