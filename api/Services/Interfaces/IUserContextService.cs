using System.Security.Claims;

namespace api.Services.Interfaces;

public interface IUserContextService
{
    ClaimsPrincipal? User { get; }
    int? GetUserId { get; }
}