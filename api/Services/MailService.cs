using Accounting.Api.Configuration;
using Accounting.Api.Entities;
using Accounting.Api.Models.Mail;
using Accounting.Api.Services.Interfaces;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace Accounting.Api.Services
{
    public class MailService(MailSettings mailSettings) : IMailService
    {
        public async Task<MailjetResponse> SendMailAsync(Account user, string subject, string htmlContent)
        {
            MailjetClient client = new MailjetClient(mailSettings.ApiKey, mailSettings.ApiSecret)
            {
            };
            var messageToSend = JObject.FromObject(CreateMailMessage(user, subject, htmlContent));

            MailjetRequest request = new MailjetRequest
            {
                Resource = SendV31.Resource
            }
            .Property(Send.Messages, new JArray(messageToSend));

            return await client.PostAsync(request);
        }

        private MailObjMessage CreateMailMessage(Account user, string subject, string htmlContent)
        {
            return new MailObjMessage(mailSettings.FromEmail, "Accounting",
            user.EmailAddress, $"{user.FirstName} {user.LastName}",
            subject, htmlContent);
        }
    }
}