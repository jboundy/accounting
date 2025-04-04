using Accounting.Api.Context;
using FastEndpoints;

namespace Accounting.Api.Features.Invoices.UpdateInvoice
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
            Put("invoice");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.UpdateInvoice(req.Invoice);
        }
    }
}