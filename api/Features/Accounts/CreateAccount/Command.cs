using Accounting.Api.Entities;

namespace Accounting.Api.Features.Accounts.CreateAccount
{
    public record Command(string firstName, string lastName, string userName, string password, CancellationToken ct);
}