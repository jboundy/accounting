using FastEndpoints;

namespace Accounting.Api.Features.Expenses.CreateExpense
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("expenses");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.CreateExpense(req.expense);
        }
    }
}