using FastEndpoints;

namespace Accounting.Api.Features.Expenses.GetExpense
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("expenses/{id}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await SendAsync(Response, StatusCodes.Status200OK, ct);
        }
    }
}