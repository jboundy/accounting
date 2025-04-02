using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Invoices.CreateInvoice
{
    public static class Data
    {
        internal static async Task<Response?> CreateInvoice(Invoice obj)
        {
            using (var context = new AccountingContext())
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