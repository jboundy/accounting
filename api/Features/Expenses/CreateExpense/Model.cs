using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Expenses.CreateExpense
{
    public class Request
    {
        public Expense expense { get; set; }
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