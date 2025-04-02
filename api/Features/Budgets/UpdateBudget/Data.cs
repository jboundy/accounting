using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Budgets.UpdateBudget
{
    public class Data
    {
        internal static async Task<Response?> UpdateInvoice(AccountingContext context, Budget obj)
        {
            using (context)
            {
                var result = context.Budgets.Update(obj);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}