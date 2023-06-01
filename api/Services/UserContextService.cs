using System.Security.Claims;
using api.Services.Interfaces;

namespace api.Services;

public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor contextAccessor)
    {
        _httpContextAccessor = contextAccessor;
    }
    
    
    public ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
    public int? GetUserId => User is null ? null: int.Parse(User?.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
}