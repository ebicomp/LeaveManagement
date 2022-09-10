using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings EmailSettings { get; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            EmailSettings = emailSettings.Value;
        }

        

        public async Task<bool> SendEmail(Email email)
        {
            throw new NotImplementedException();

        }
    }
}
