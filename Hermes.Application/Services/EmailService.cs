using Hermes.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
