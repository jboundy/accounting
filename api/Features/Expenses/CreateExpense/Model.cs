using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Expenses.CreateExpense
{
    public class Request
    {
        public required Expense Expense { get; set; }
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