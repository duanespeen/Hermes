using Hermes.Application.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Hermes.Application.Services
{
    public class JWTService : IJWTService
    {
        private readonly string _secret;

        public JWTService()
        {
            if (Environment.GetEnvironmentVariable("JWT_SECRET") is not null)
            {
                _secret = Environment.GetEnvironmentVariable("JWT_SECRET");
            }
        }
        public string GenerateJWT()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secret)),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            });
            return tokenHandler.WriteToken(token);
        }

        //Validate JWT
        
        
    }
}
