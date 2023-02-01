using Hermes.Application.Abstractions;

namespace Hermes.Application.Services
{
    public class EmailService : IEmailService
    {
        //Will be used to send Email in the future
        //Need to configure SMTP server
        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
