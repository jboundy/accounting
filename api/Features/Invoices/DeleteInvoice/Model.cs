using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Invoices.DeleteInvoice
{
    public class Request
    {
        public Invoice invoice { get; set; }
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