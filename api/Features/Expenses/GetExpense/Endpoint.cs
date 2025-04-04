using Accounting.Api.Context;
using FastEndpoints;

namespace Accounting.Api.Features.Expenses.GetExpense
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
            Get("expenses/{id}");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.GetExpense(req.Id);
        }
    }
}