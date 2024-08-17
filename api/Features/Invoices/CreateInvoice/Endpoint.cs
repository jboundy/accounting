using FastEndpoints;

namespace Accounting.Api.Features.Invoices.CreateInvoice
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("invoices");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.CreateInvoice(req.invoice);
        }
    }
}