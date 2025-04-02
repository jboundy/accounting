using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Budgets.DeleteBudget
{
    public static class Data
    {
        internal static async Task<Response?> DeleteBudget(Budget budget)
        {
            using (var context = new AccountingContext())
            {
                context.Budgets.Remove(budget);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}