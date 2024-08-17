using FastEndpoints;

namespace Account.Api.Features.Invoices.SendInvoice
{
    public class Request
    {
        public int invoiceId { get; set; }
    }

    public class Response
    {
        public bool saved { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }
}