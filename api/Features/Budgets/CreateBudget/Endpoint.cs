using FastEndpoints;

namespace Accounting.Api.Features.Budgets.CreateBudget
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("budget");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var response = await Data.CreateBudget(req.Budget);
            await SendAsync(response, StatusCodes.Status200OK, ct);
        }
    }
}