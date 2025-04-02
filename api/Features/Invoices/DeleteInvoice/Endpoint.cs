using FastEndpoints;

namespace Accounting.Api.Features.Invoices.DeleteInvoice
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Delete("invoice");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.DeleteInvoice(req.Invoice);
        }
    }
}