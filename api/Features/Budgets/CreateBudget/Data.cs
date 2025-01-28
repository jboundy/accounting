using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Budgets.CreateBudget
{
    public static class Data
    {
        internal static async Task<Response?> CreateBudget(Budget obj)
        {
            using (var context = new AccountingContext())
            {
                var result = await context.Budgets.AddAsync(obj);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    saved = saved == 1
                };
            }
        }
    }
}