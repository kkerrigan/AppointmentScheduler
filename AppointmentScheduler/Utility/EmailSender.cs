using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;

namespace AppointmentScheduler.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient("2befb4df1ff1be3e080cf318e21e4de4", "3e1185d441ecc1a0a1b42d4f230ad05e")
            {
                
            };
            MailjetRequest request = new MailjetRequest
                {
                    Resource = Send.Resource,
                }
                .Property(Send.FromEmail, "k.burnard@hotmail.com")
                .Property(Send.FromName, "Appointment Scheduler")
                .Property(Send.Subject, subject)
                .Property(Send.HtmlPart, htmlMessage)
                .Property(Send.Recipients, new JArray
                {
                    new JObject
                    {
                        { "Email", email },
                    }
                });
                
            MailjetResponse response = await client.PostAsync(request);
        }
    }
}
