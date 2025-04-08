using FastEndpoints;

namespace Accounting.Api.Features.Expenses.DeleteExpense
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {

        public override void Configure()
        {
            Delete("expenses");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await SendAsync(Response, StatusCodes.Status200OK, ct);
        }
    }
}