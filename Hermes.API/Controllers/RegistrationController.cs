using Hermes.Application.Abstractions;
using Hermes.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.API.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
        
        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            var result = await _registrationService.RegisterAsync(model);
            if (result.Item1 is not null)
            {
                return Ok(result.Item1);
            }
            return BadRequest(result.Item2);
        }
    }
}
