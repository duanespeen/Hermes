using Hermes.Domain.Models;
using Hermes.Domain.ViewModels;
using Hermes.Application.Abstractions;
using Hermes.Database;
using System.Diagnostics;
using LanguageExt;

namespace Hermes.Application.Abstractions
{
    public class RegistrationService : IRegistrationService
    {
        private readonly HermesContext _context;

        public RegistrationService(HermesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method <c> RegisterUser </c> is used to register a new user and store in database.
        /// <param name="model"> RegistrationViewModel contains data from the registration form </param>
        /// <returns> 
        /// Returns the registered User IF the registration was successful. User is then used to generate JWT.
        /// Returns null if exception was thrown
        /// </returns>
        public async Task<Either<User, string>> RegisterAsync(RegistrationViewModel model)
        {
            var duplicate = _context.Users.FirstOrDefault(u =>
                u.NormalizedUsername == model.Username.ToUpper()
            );
            
            if (duplicate is not null)
            {
                return "Username already exists";
            }

            var user = new User() { Username = model.Username, Password = model.Password, NormalizedUsername = model.Username.ToUpper() };
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
