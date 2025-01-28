using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Budgets.DeleteBudget
{
    public class Request
    {
        public Budget budget { get; set; }
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