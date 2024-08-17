using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Invoices.UpdateInvoice
{
    public class Data
    {
        internal static async Task<Response?> UpdateInvoice(Invoice obj)
        {
            using (var context = new AccountingContext())
            {
                var result = context.Invoices.Update(obj);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    saved = saved == 1
                };
            }
        }
    }
}