﻿namespace Hermes.Application.Abstractions
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
