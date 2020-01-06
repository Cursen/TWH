using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Repository.EntityRepositories
{
    /*public class UserRepository : BaseRepository<User, Guid>
    {
        private static string code = "NLn9cB4tTkWxuGZSnniFiJaMPjG3jrvQk7/V3U3C2eEJGle8KFuS3c/wXQi0VXWZF1uO/xYh+QJxgitcZtNS+w==";
        public UserRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public static string GenerateToken(string username)
        {
            byte[] key = Convert.FromBase64String(code);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, username)}),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
    }*/
}
