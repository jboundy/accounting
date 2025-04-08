using Accounting.Api.Entities;

namespace Accounting.Api.Features.Budgets.UpdateBudget
{
    public record Command(Budget budget, CancellationToken ct);
}