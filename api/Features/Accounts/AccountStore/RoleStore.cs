using Accounting.Api.Entities;
using Marten;
using Microsoft.AspNetCore.Identity;

namespace Accounting.Api.Features.Accounts.AccountStore
{
    public class RoleStore : IRoleStore<Role>
    {
        private readonly IDocumentSession _session;

        public RoleStore(IDocumentSession session)
        {
            _session = session;
        }

        public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            _session.Store(role);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            _session.Delete(role);
            return Task.FromResult(IdentityResult.Success);
        }

        public async Task<Role?> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return await _session.LoadAsync<Role>(roleId, cancellationToken);
        }

        public async Task<Role?> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return await _session.Query<Role>()
                .FirstOrDefaultAsync(r => r.NormalizedName == normalizedRoleName, cancellationToken);
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.NormalizedName);

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Id.ToString());

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
            => Task.FromResult(role.Name);

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            _session.Store(role);
            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose() { }
    }
}