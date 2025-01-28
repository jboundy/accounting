using FastEndpoints;

namespace Account.Api.Features.Invoices.SendInvoice
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("invoice/sendinvoice");
        }

        // public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        // {

        //psuedo --------------------
        //get invoice data
        //build email message
        //send to recipient
        //add date of notice to the invoice obj
        //--------------------------------
        //}
    }
}