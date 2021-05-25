using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_ZIwG.Domain.Auth.Interfaces;
using Project_ZIwG.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public string GetSecurityToken(string username, string password)
        {
            if (!CheckUser(username, password))
            {
                return null;
            }
            var user = _userRepository.GetByUsername(username);
            var token = CreateJwtToken(user.Id.ToString());
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
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

        private JwtSecurityToken CreateJwtToken(string userId)
        {
            if (userId is null)
            {
                return null;
            }
            var issuerSingningKey = new SymmetricSecurityKey(
                                        Encoding.UTF8.GetBytes("Yq3t6w9z$C&F)J@NcRfUjXn2r4u7x!A%D*G-KaPdSgVkYp3s6v8y/B?E(H+MbQeThWmZq4t7w!z$C&F)J@NcRfUjXn2r5u8x/A?D*G-KaPdSgVkYp3s6v9y$B&E)H+Mb"));
            var tokenExpirationMinutes = 10;

            return new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: GetClaims(userId),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(tokenExpirationMinutes),
                signingCredentials: new SigningCredentials(issuerSingningKey, SecurityAlgorithms.HmacSha256)
            );
        }

        private List<Claim> GetClaims(string userId)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("id", userId));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            return claims;
        }

        private ClaimsPrincipal GetClaimsPrincipal(string userId)
        {
            var claims = GetClaims(userId);
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
    }
}
