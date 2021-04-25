using System.Security.Claims;

namespace Project_ZIwG.Domain.Auth.Interfaces
{
    public interface IAuthenticator
    {
        ClaimsPrincipal GetUserClaimsPrincipal(string username, string password);
    }
}
