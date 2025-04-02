using FastEndpoints;

namespace Accounting.Api.Features.Invoices.GetInvoice
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("invoice/{id}");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.GetInvoice(req.Id);
        }
    }
}