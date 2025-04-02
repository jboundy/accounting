using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Expenses.CreateExpense
{
    public static class Data
    {
        internal static async Task<Response?> CreateExpense(Expense obj)
        {
            using (var context = new AccountingContext())
            {
                var result = await context.Expenses.AddAsync(obj);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}