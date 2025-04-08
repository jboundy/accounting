using FastEndpoints;

namespace Accounting.Api.Features.Invoices.CreateInvoice
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("invoice");
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await SendAsync(Response, StatusCodes.Status200OK, ct);
        }
    }
}