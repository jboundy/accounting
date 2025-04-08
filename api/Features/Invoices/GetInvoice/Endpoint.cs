using FastEndpoints;

namespace Accounting.Api.Features.Invoices.GetInvoice
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("invoice/{id}");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await SendAsync(Response, StatusCodes.Status200OK, ct);
        }
    }
}