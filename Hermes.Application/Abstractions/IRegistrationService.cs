using Hermes.Domain.Models;
using Hermes.Domain.ViewModels;
using LanguageExt;

namespace Hermes.Application.Abstractions
{
    public interface IRegistrationService
    {
        public Task<Either<User, string>> RegisterAsync(RegistrationViewModel model);
    }
}
