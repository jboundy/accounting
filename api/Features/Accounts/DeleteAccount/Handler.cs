using Accounting.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Wolverine;

namespace Accounting.Api.Features.Accounts.DeleteAccount
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
            var user = await _userManager.FindByEmailAsync(command.userName);
            var result = await _userManager.DeleteAsync(user!);
            if (result.Succeeded)
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