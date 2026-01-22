using System.Security.Claims;

namespace ECommerce.Services
{
    public sealed class CurrentUser : ICurrentUser
    {
        public Guid UserId { get; }
        public string Role { get; }

        public CurrentUser(IHttpContextAccessor accessor)
        {
            var user = accessor.HttpContext?.User
                ?? throw new UnauthorizedAccessException();

            UserId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
            Role = user.FindFirstValue(ClaimTypes.Role)!;
        }
    }

}
