using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Entities;
using FastEndpoints;

namespace Accounting.Api.Features.Expenses.UpdateExpense
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