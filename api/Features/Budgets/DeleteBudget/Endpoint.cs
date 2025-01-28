using FastEndpoints;

namespace Accounting.Api.Features.Budgets.DeleteBudget
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Delete("budget");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.DeleteBudget(req.budget);
        }
    }
}