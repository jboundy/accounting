using Accounting.Api.Entities;
using Mailjet.Client;

namespace Accounting.Api.Services.Interfaces
{
    public interface IMailService
    {
        Task<MailjetResponse> SendMailAsync(Account user, string subject, string htmlContent);
    }
}