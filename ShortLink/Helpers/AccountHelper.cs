using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ShortLink.Models;

namespace ShortLink.Helpers
{
    public class AccountHelper
    {
        
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthConfig.Issuer,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(5)),
                signingCredentials: new SigningCredentials(AuthConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
