using FastEndpoints;

namespace Accounting.Api.Features.Expenses.UpdateExpense
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Put("expenses");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.UpdateExpense(req.Expense);
        }
    }
}