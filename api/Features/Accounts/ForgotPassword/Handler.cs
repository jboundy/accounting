using System.Web;
using Accounting.Api.Configuration;
using Accounting.Api.Entities;
using Accounting.Api.Models.Mail;
using Accounting.Api.Services.Interfaces;
using Mailjet.Client;
using Microsoft.AspNetCore.Identity;
using Wolverine;

namespace Accounting.Api.Features.Accounts.ForgotPassword
{
    public class Handler : IWolverineHandler
    {
        UserManager<Account> _userManager;
        HostSettings _hostSettings;
        IMailService _mailService;

        public Handler(UserManager<Account> userManager, HostSettings hostSettings, IMailService mailService)
        {
            _userManager = userManager;
            _hostSettings = hostSettings;
            _mailService = mailService;
        }

        public async Task<Response> Handle(Command command)
        {
            var user = await _userManager.FindByEmailAsync(command.email);
            var code = await _userManager.GeneratePasswordResetTokenAsync(user!);
            var url = $"{_hostSettings.BaseUrl}/account/resetpassword?userId={user.Id}&code={HttpUtility.UrlEncode(code)}";
            var htmlContent = $"<html><body><h1>{url}</h1></body></html>";
            MailjetResponse response = await _mailService.SendMailAsync(user, "Password Reset", htmlContent);
            if (response.IsSuccessStatusCode)
            {
                return new Response
                {
                    Saved = true
                };
            }

            return new Response
            {
                Saved = false
            };
        }
    }
}