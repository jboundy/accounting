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
        internal static async Task<Response?> GetBudget(int id)
        {
            using (var context = new AccountingContext())
            {
                var result = await context.Budgets.SingleOrDefaultAsync(x => x.id == id);

                return new Response
                {
                    budget = result
                };
            }
        }
    }
}