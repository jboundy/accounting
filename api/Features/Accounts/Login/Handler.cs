using Accounting.Api.Entities;
using Marten;
using Microsoft.AspNetCore.Identity;
using Wolverine;

namespace Accounting.Api.Features.Accounts.Login
{
    public class Handler : IWolverineHandler
    {
        private readonly UserManager<Account> _userManager;
        public Handler(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response> Handle(Command command)
        {

            var user = await _userManager.FindByEmailAsync(command.userName);
            var passwordResult = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, command.password);

            return new Response
            {
                Saved = identityResult.Succeeded
            };
        }
    }
}