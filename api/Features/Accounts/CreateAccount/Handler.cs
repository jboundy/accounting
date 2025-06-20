using Accounting.Api.Entities;
using Marten;
using Microsoft.AspNetCore.Identity;
using Wolverine;

namespace Accounting.Api.Features.Accounts.CreateAccount
{
    public class Handler : IWolverineHandler
    {
        private readonly UserManager<Account> _userManager;
        private readonly IDocumentSession _session;
        public Handler(IDocumentSession session, UserManager<Account> userManager)
        {
            _session = session;
            _userManager = userManager;
        }

        public async Task<Response> Handle(Command command)
        {
            var account = new Account(command.userName, command.firstName, command.lastName);

            //TODO: need to set these values somehow
            // PhoneNumber = string.Empty;
            // Roles = new HashSet<MartenIdentityRole>(MartenIdentityRole.NameComparer);
            // Claims = new HashSet<MartenIdentityClaim>(MartenIdentityClaim.TypeAndValueAndIssuerComparer);
            // Logins = new HashSet<MartenIdentityUserLogin>(MartenIdentityUserLogin.LoginProviderAndProviderKeyComparer);
            // Tokens = new HashSet<MartenIdentityUserToken>(MartenIdentityUserToken.LoginProviderAndNameComparer);
            // RecoveryCodes = new HashSet<MartenIdentityRecoveryCode>(MartenIdentityRecoveryCode.CodeComparer);
            var identityResult = await _userManager.CreateAsync(account, command.password);
            return new Response
            {
                Saved = identityResult.Succeeded
            };
        }
    }
}