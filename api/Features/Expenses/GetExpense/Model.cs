using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Expenses.GetExpense
{
    public class Request
    {
        public int id { get; set; }
    }

    public class Response
    {
        public Expense expense { get; set; }
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {

        }
    }
}