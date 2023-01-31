using Hermes.Application.Abstractions;
using Hermes.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hermes.API.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;
        private readonly IJWTService _JWTService;

        public RegistrationController(IRegistrationService registrationService, IJWTService JWTService)
        {
            _registrationService = registrationService;
            _JWTService = JWTService;
        }
        
        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            var result = await _registrationService.RegisterAsync(model);
            return result.Match<IActionResult>(
                Left: user =>
                {
                    var token = _JWTService.CreateJWT(user);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                },
                Right: error => BadRequest(error)
            );
        }
    }
}
