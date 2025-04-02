using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Features.Budgets.GetBudget
{
    public class Data
    {
        internal static async Task<Response?> GetBudget(AccountingContext context, int id)
        {
            using (context)
            {
                var result = await context.Budgets.SingleOrDefaultAsync(x => x.Id == id);

                return new Response
                {
                    Budget = result
                };
            }
        }
    }
}