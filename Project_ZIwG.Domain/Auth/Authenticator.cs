using Microsoft.AspNetCore.Authentication.Cookies;
using Project_ZIwG.Domain.Auth.Interfaces;
using Project_ZIwG.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;

namespace Project_ZIwG.Domain.Auth
{
    public class Authenticator : IAuthenticator
    {
        private readonly IUserRepository _userRepository;

        public Authenticator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ClaimsPrincipal GetUserClaimsPrincipal(string username, string password)
        {
            if(!CheckUser(username, password))
            {
                return null;
            }
            return GetClaimsPrincipal(username);
        }

        private bool CheckUser(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user is null)
            {
                return false;
            }
            return password == user.Password;
        }

        private ClaimsPrincipal GetClaimsPrincipal(string username)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("username", username));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
    }
}
