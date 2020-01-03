using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TWH.Entities.Models
{
    class Token
    {
        //for reference visist: https://www.red-gate.com/simple-talk/dotnet/net-development/jwt-authentication-microservices-net/
        private static string code = "uFQBUPlJ79d9e7zw2MaqbXLgahJZBacncjbkxkIMTfzNhXvr0wPzOO2a5fTo2te80wz/neCY2E/5Pg8K1iYqag==";
        public static string GenerateToken(string username)
        {
            byte[] key = Convert.FromBase64String(code);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
