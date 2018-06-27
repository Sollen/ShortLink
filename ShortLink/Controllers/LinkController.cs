using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ShortLink.Models;

namespace ShortLink.Controllers
{
    [Produces("application/json")]
    [Route("api/Link")]
    public class LinkController : Controller
    {
        private const string CHARS = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-";
        const string SecretKey = "dhx|$O~[c>k8+]m1W<OG";

        public string Generate()
        {
            Random rnd = new Random();
            string uid = "";
            for (int i = 0; i < 5; i++)
            {
                uid += CHARS[rnd.Next(0, 63)];
            }
            return uid;
        }

        public string GetToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: "MyAuthServer",
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(5)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey)), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}