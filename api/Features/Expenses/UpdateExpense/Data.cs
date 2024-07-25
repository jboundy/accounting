using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Expenses.UpdateExpense
{
    public static class Data
    {
        internal static async Task<Response?> UpdateExpense(Expense obj)
        {
            using (var context = new AccountingContext())
            {
                var result = context.Expenses.Update(obj);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    saved = saved == 1
                };
            }
        }
    }
}