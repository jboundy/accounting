using Accounting.Api.Context;
using FastEndpoints;

namespace Accounting.Api.Features.Budgets.CreateBudget
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
            Post("budget");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var response = await Data.CreateBudget(_context, req.Budget);
            await SendAsync(response, StatusCodes.Status200OK, ct);
        }
    }
}