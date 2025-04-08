namespace Accounting.Api.Features.Budgets.GetBudget
{
    public record Command(int id, CancellationToken ct);
}