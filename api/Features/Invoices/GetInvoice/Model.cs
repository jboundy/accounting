using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Invoices.GetInvoice
{
    public class Request
    {
        public int Id { get; set; }
    }

    public class Response
    {
        public required Invoice Invoice { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }
}