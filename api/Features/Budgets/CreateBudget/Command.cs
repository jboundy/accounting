using Accounting.Api.Entities;

namespace Accounting.Api.Features.Budgets.CreateBudget
{
    public record Command(Budget budget, CancellationToken ct);
}