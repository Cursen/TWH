using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TWH.Entities.Models
{
    public class Token
    {
        //for reference visist: https://www.red-gate.com/simple-talk/dotnet/net-development/jwt-authentication-microservices-net/
        //https://www.red-gate.com/simple-talk/dotnet/net-development/jwt-authentication-microservices-net/
        //TODO change this string to a new gened one, as it will be a copy of another one otherwise.
        private static string code = "uFQBUPlJ79d9e7zw2MaqbXLgahJZBacncjbkxkIMTfzNhXvr0wPzOO2a5fTo2te80wz/neCY2E/5Pg8K1iYqag==";
        public static string GenerateToken(string username, int expiresMin = 30)
        {
            var key = Convert.FromBase64String(code);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddMinutes(Convert.ToInt32(expiresMin)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);
            return token;
        }
    }
}
