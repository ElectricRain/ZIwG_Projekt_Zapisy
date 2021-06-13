using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project_ZIwG.Domain.Auth.Interfaces;
using Project_ZIwG.Domain.Auth.Models;
using Project_ZIwG.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Project_ZIwG.Domain.Auth
{
    public class Authenticator : IAuthenticator
    {
        private readonly IUserRepository _userRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IUserRolesRepository _userRolesRepository;
        private readonly AuthSecrets _options;

        public Authenticator(IUserRepository userRepository, IOptions<AuthSecrets> options, IRolesRepository rolesRepository, IUserRolesRepository userRolesRepository)
        {
            _userRepository = userRepository;
            _rolesRepository = rolesRepository;
            _userRolesRepository = userRolesRepository;
            _options = options.Value;
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
                                        Encoding.UTF8.GetBytes(_options.Key));

            return new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: GetClaims(userId),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_options.ExpirationTime),
                signingCredentials: new SigningCredentials(issuerSingningKey, SecurityAlgorithms.HmacSha256)
            );
        }

        private List<Claim> GetClaims(string userId)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userId));
            claims.AddRange(GetRolesClaims(userId));
            return claims;
        }

        private List<Claim> GetRolesClaims(string userId)
        {
            var claims = new List<Claim>();
            var rolesId = _userRolesRepository.GetList().Where(x => x.UserId == new Guid(userId)).Select(x => x.RoleId).ToList();
            var roles = _rolesRepository.GetList().Where(x => rolesId.Contains(x.Id)).ToList();
            foreach (var role in roles)
            {
                var roleClaim = role.RoleName;
                claims.Add(new Claim(ClaimTypes.Role, roleClaim));
            }
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
