using FastEndpoints;

namespace Accounting.Api.Features.Invoices.UpdateInvoice
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
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