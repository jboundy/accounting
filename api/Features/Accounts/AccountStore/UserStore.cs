using Accounting.Api.Entities;
using Marten;
using Marten.Services;
using Microsoft.AspNetCore.Identity;

namespace Accounting.Api.Features.Accounts.AccountStore
{
    public class UserStore : IUserStore<Account>,
            IUserPasswordStore<Account>,
            IUserEmailStore<Account>
    {
        private readonly IDocumentSession _session;
        private readonly IRoleStore<Role> _roleStore;

        public UserStore(IDocumentSession session, IRoleStore<Role> roleStore)
        {
            _roleStore = roleStore;
            _session = session;
        }

        public async Task<IdentityResult> CreateAsync(Account user, CancellationToken cancellationToken)
        {
            _session.Store(user);
            await _session.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Account user, CancellationToken cancellationToken)
        {
            _session.Delete(user);
            await _session.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<Account?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await _session.LoadAsync<Account>(userId);
        }

        public Task<Account?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = _session.Query<Account>()
                .FirstOrDefault(x => x.NormalizedUserName == normalizedUserName);
            return Task.FromResult(user);
        }

        public Task<string> GetUserIdAsync(Account user, CancellationToken cancellationToken)
            => Task.FromResult(user.Id.ToString());

        public Task<string> GetUserNameAsync(Account user, CancellationToken cancellationToken)
            => Task.FromResult(user.UserName);

        public Task SetUserNameAsync(Account user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(Account user, CancellationToken cancellationToken)
            => Task.FromResult(user.NormalizedUserName);

        public Task SetNormalizedUserNameAsync(Account user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(Account user, CancellationToken cancellationToken)
        {
            _session.Store(user);
            await _session.SaveChangesAsync(cancellationToken);
            return IdentityResult.Success;
        }

        public Task SetPasswordHashAsync(Account user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(Account user, CancellationToken cancellationToken)
            => Task.FromResult(user.PasswordHash);

        public Task<bool> HasPasswordAsync(Account user, CancellationToken cancellationToken)
            => Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));

        public Task SetEmailAsync(Account user, string email, CancellationToken cancellationToken)
        {
            user.EmailAddress = email;
            return Task.CompletedTask;
        }

        public Task<string> GetEmailAsync(Account user, CancellationToken cancellationToken)
            => Task.FromResult(user.EmailAddress);

        public Task<bool> GetEmailConfirmedAsync(Account user, CancellationToken cancellationToken)
            => Task.FromResult(user.IsEmailConfirmed);

        public Task SetEmailConfirmedAsync(Account user, bool confirmed, CancellationToken cancellationToken)
        {
            user.IsEmailConfirmed = confirmed;
            return Task.CompletedTask;
        }

        public async Task<Account?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return (await _session.QueryAsync<Account>("where data ->> 'NormalizedEmailAddress' = ?", cancellationToken, normalizedEmail)).FirstOrDefault();
        }

        public Task<string> GetNormalizedEmailAsync(Account user, CancellationToken cancellationToken)
            => Task.FromResult(user.NormalizedEmailAddress);

        public Task SetNormalizedEmailAsync(Account user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmailAddress = normalizedEmail;
            return Task.CompletedTask;
        }

        public async Task AddToRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            var roles = user.Roles.Select(x => x.Name == roleName);
            if (roles.IsEmpty())
            {
                var roleToAdd = await _roleStore.FindByNameAsync(roleName.ToUpper(), cancellationToken);
                if (roleToAdd != null)
                {
                    user.Roles.Add(roleToAdd);
                    _session.Store(user);
                    await _session.SaveChangesAsync(cancellationToken);
                }
            }
        }

        public async Task RemoveFromRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
        {
            user.Roles.RemoveWhere(r => string.Equals(r.Name, roleName, StringComparison.OrdinalIgnoreCase));
            _session.Store(user);
            await _session.SaveChangesAsync(cancellationToken);
        }

        public Task<IList<string>> GetRolesAsync(Account user, CancellationToken cancellationToken)
            => Task.FromResult((IList<string>)user.Roles);

        public Task<bool> IsInRoleAsync(Account user, string roleName, CancellationToken cancellationToken)
            => Task.FromResult(user.Roles.Any(x => x.Name == roleName));

        public async Task<IReadOnlyList<Account>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            return await _session.Query<Account>()
                .Where(u => u.Roles.Any(x => x.Name == roleName))
                .ToListAsync(cancellationToken);
        }

        public void Dispose() { }
    }
}