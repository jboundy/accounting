using FastEndpoints;

namespace Accounting.Api.Features.Invoices.SendInvoice
{
    public class Request
    {
        public int InvoiceId { get; set; }
    }

    public class Response
    {
        public bool Saved { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }
}