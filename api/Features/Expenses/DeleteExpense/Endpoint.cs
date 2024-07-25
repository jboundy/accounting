using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;

namespace Accounting.Api.Features.Expenses.DeleteExpense
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Delete("expenses");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.DeleteExpense(req.expense);
        }
    }
}