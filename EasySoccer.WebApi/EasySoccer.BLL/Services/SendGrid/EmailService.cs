﻿using EasySoccer.BLL.Infra.Services.SendGrid;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace EasySoccer.BLL.Services.SendGrid
{
    public class EmailService : IEmailService
    {
        private string _apiKey = "";
        private string _emailFrom = "";
        private string _userFrom = "";
        private string _validationErrorTemplateId = "";
        public EmailService(IConfiguration configuration)
        {
            var config = configuration.GetSection("SendGridConfiguration");
            if (config != null)
            {
                _apiKey = config.GetValue<string>("ApiKey");
                _emailFrom = config.GetValue<string>("EmailFrom");
                _userFrom = config.GetValue<string>("UserNameFrom");
                _validationErrorTemplateId = config.GetValue<string>("ValidationErrorTemplateId");
            }
        }
        private async Task SendEmailAsync(string emailTo, string userNameTo, string templateId, object templateData)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_emailFrom, _userFrom);
            var to = new EmailAddress(emailTo, userNameTo);
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, templateData);
            await client.SendEmailAsync(msg);
        }

        public async Task SendValidationErrorsEmailAsync(string emailTo, string userNameTo, string[] errors)
        {
            string formattedErrors = "";
            foreach (var item in errors)
            {
                formattedErrors += String.Format("<p>{0}</p>", item);
            }
            await SendEmailAsync(emailTo, userNameTo, _validationErrorTemplateId, new { firstName= userNameTo,  errors = formattedErrors });
        }
    }
}
