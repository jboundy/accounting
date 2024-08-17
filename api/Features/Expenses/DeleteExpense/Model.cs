using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Expenses.DeleteExpense
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