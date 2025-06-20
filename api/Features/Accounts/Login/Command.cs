using Accounting.Api.Entities;

namespace Accounting.Api.Features.Accounts.Login
{
    public record Command(string userName, string password, CancellationToken ct);
}