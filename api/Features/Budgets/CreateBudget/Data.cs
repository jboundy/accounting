using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Budgets.CreateBudget
{
    public static class Data
    {
        internal static async Task<Response?> CreateBudget(AccountingContext context, Budget obj)
        {
            using (context)
            {
                var result = await context.Budgets.AddAsync(obj);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}