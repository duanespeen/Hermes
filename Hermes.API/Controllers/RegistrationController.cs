using Hermes.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.API.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService, IEmailService emailService, IPasswordService passwordService, IJWTService jWTService)
        {
            _registrationService = registrationService;
        }
        
        [HttpPost]
        [Route("api/registration")]
        public Task<IActionResult> Register(RegistrationViewModel model)
        {
            var result = await _registrationService.RegisterAsync(model);
            if (result.Success)
            {
                var token = _JWTService.GenerateToken(result.Data);
                return Ok(new { token });
            }

            return BadRequest(result);
        }
    }
}
