using Hermes.Domain.Models;
using Hermes.Domain.ViewModels;

namespace Hermes.Application.Abstractions
{
    public interface IRegistrationService
    {   
        public Task<(User?, string?)> RegisterAsync(RegistrationViewModel model);
    }
}
