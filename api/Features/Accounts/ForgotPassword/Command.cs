
namespace Accounting.Api.Features.Accounts.ForgotPassword
{
    public record Command(string email, CancellationToken ct);
}