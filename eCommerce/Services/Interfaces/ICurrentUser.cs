namespace ECommerce.Services.Interfaces
{
    public interface ICurrentUser
    {
        Guid UserId { get; }
        string Role { get; }
    }
}
