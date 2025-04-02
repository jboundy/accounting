using Accounting.Api.Context;
using FastEndpoints;

namespace Accounting.Api.Features.Expenses.CreateExpense
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        private readonly AccountingContext _context;

        public Endpoint(AccountingContext context)
        {
            _context = context;
        }
        public override void Configure()
        {
            Post("expenses");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.CreateExpense(_context, req.Expense);
        }
    }
}