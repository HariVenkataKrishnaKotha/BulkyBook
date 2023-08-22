﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utility
{
    public class EmailSender : IEmailSender
    {
        public string SendGridSecret { get; set; }

        public EmailSender(IConfiguration _config)
        {
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var client = new SendGridClient(SendGridSecret);
            var from = new EmailAddress("harivenkatakrishnak@gmail.com", "Bulky Book");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject,"", htmlMessage);
            return client.SendEmailAsync(msg);

        }
    }
}
