using FastEndpoints;

namespace Accounting.Api.Features.Budgets.CreateBudget
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("budget");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.CreateBudget(req.budget);
        }
    }
}