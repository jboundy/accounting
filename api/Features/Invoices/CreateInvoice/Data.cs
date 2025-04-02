using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Invoices.CreateInvoice
{
    public static class Data
    {
        internal static async Task<Response?> CreateInvoice(AccountingContext context, Invoice obj)
        {
            using (context)
            {
                var result = await context.Invoices.AddAsync(obj);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}