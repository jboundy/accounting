using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Invoices.GetInvoice
{
    public class Request
    {
        public int id { get; set; }
    }

    public class Response
    {
        public Invoice invoice { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }
}