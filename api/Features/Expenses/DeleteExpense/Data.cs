using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Expenses.DeleteExpense
{
    public static class Data
    {
        internal static async Task<Response?> DeleteExpense(AccountingContext context, Expense obj)
        {
            using (context)
            {
                context.Expenses.Remove(obj);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}