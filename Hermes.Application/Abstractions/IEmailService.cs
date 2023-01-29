﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Abstractions
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
