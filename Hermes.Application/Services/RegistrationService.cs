using Hermes.Domain.Models;
using Hermes.Domain.ViewModels;
using Hermes.Application.Abstractions;

namespace Hermes.Application.Abstractions
{
    public class RegistrationService : IRegistrationService
    {

        public Task<User> RegisterAsync(RegistrationViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
