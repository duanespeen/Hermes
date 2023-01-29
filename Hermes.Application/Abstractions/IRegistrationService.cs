using Hermes.Domain.Models;
using Hermes.Domain.ViewModels;

namespace Hermes.Application.Abstractions
{
    public class IRegistrationService
    {

        public Task<User> RegisterAsync(RegistrationViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
