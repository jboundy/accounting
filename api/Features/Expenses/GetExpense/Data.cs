using Accounting.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Features.Expenses.GetExpense
{
    public static class Data
    {
        internal static async Task<Response?> GetExpense(AccountingContext context, int id)
        {
            using (context)
            {
                var result = await context.Expenses.SingleOrDefaultAsync(x => x.Id == id);

                return new Response
                {
                    Expense = result
                };
            }
        }
    }
}