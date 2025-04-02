using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Invoices.UpdateInvoice
{
    public class Data
    {
        internal static async Task<Response?> UpdateInvoice(AccountingContext context, Invoice obj)
        {
            using (context)
            {
                var result = context.Invoices.Update(obj);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}