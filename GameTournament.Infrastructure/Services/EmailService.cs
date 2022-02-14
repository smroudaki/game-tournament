using GameTournament.Application.Common.Interfaces;
using GameTournament.Infrastructure.Helpers;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailService(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            var mailMessage = CreateEmailMessage(to, subject, body);
            await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(string to, string subject, string body)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(MailboxAddress.Parse(_emailConfiguration.From));
            emailMessage.To.Add(MailboxAddress.Parse(to));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(TextFormat.Text) { Text = body };

            return emailMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password);
                await client.SendAsync(mailMessage);
            }
            catch
            {
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }
}
