using Hermes.Application.Abstractions;
using Hermes.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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
        public async Task<IActionResult> Register([FromBody] RegistrationViewModel model)
        {
            var result = await _registrationService.RegisterAsync(model);
            return result.Match<IActionResult>(
                Left: user =>
                {
                    var token = _JWTService.CreateJWT(user);
                    var options = new CookieOptions
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.None,
                        Expires = DateTime.UtcNow.AddMinutes(20)
                    };
                    HttpContext.Response.Cookies.Append("jwt", new JwtSecurityTokenHandler().WriteToken(token), options);
                    return Ok();
                },
                Right: BadRequest
            );
        }
    }
}
