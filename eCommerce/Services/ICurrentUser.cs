namespace ECommerce.Services
{
    public interface ICurrentUser
    {
        Guid UserId { get; }
        string Role { get; }
    }
}
