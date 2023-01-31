using Hermes.Domain.Models;
using System.IdentityModel.Tokens.Jwt;


namespace Hermes.Application.Abstractions
{
    public interface IJWTService
    {
        public JwtSecurityToken CreateJWT(User user);
    }
}
