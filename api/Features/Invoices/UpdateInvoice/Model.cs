using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Invoices.UpdateInvoice
{
    public class Request
    {
        public Invoice Invoice { get; set; }
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