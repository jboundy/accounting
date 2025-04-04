using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Context;
using FastEndpoints;

namespace Accounting.Api.Features.Budgets.GetBudget
{
    public sealed class Endpoint : Endpoint<Request, Response>
    {
        private readonly AccountingContext _context;

        public Endpoint(AccountingContext context)
        {
            _context = context;
        }
        public override void Configure()
        {
            Get("budget/{id}");
        }

        public override async Task<Response> HandleAsync(Request req, CancellationToken ct)
        {
            return await Data.GetBudget(req.Id);
        }
    }
}