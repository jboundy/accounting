using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Expenses.GetExpense
{
    public class Request
    {
        public int Id { get; set; }
    }

    public class Response
    {
        public required Expense Expense { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }
}