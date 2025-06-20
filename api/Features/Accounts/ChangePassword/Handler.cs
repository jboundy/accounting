using Accounting.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Wolverine;

namespace Accounting.Api.Features.Accounts.ChangePassword
{
    public class Handler : IWolverineHandler
    {
        UserManager<Account> _userManager;
        public Handler(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response> Handle(Command command)
        {
            var user = await _userManager.FindByIdAsync(command.userId);
            var passwordResetResult = await _userManager.ChangePasswordAsync(user!, command.currentPassword, command.newPassword);
            if (passwordResetResult.Succeeded)
            {
                return new Response
                {
                    Saved = true
                };
            }
            else
            {
                return new Response
                {
                    Saved = false
                };
            }

        }
    }
}