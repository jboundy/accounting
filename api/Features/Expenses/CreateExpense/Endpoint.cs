using FastEndpoints;

namespace Accounting.Api.Features.Expenses.CreateExpense
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {

        public override void Configure()
        {
            Post("expenses");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await SendAsync(Response, StatusCodes.Status200OK, ct);
        }
    }
}