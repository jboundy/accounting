using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Context;
using Accounting.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Features.Expenses.DeleteExpense
{
    public static class Data
    {
        internal static async Task<Response?> DeleteExpense(Expense obj)
        {
            using (var context = new AccountingContext())
            {
                context.Expenses.Remove(obj);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    saved = saved == 1
                };
            }
        }
    }
}