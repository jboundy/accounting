using Accounting.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Wolverine;

namespace Accounting.Api.Features.Accounts.ResetPassword
{
    public class Handler : IWolverineHandler
    {
        private UserManager<Account> _userManager;

        public Handler(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response> Handle(Command command)
        {
            var user = await _userManager.FindByIdAsync(command.req.UserId);
            var passwordResetResult = await _userManager.ResetPasswordAsync(user!, command.req.Code, command.req.Password);
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