using FastEndpoints;

namespace Accounting.Api.Features.Expenses.GetExpense
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("expenses/{id}");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.GetExpense(req.Id);
        }
    }
}