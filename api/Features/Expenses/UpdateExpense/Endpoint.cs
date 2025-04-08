using FastEndpoints;

namespace Accounting.Api.Features.Expenses.UpdateExpense
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Put("expenses");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await SendAsync(Response, StatusCodes.Status200OK, ct);
        }
    }
}