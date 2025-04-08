using Accounting.Api.Entities;

namespace Accounting.Api.Features.Budgets.DeleteBudget
{
    public record Command(Budget budget, CancellationToken ct);
}