using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Invoices.DeleteInvoice
{
    public static class Data
    {
        internal static async Task<Response?> DeleteInvoice(Invoice invoice)
        {
            using (var context = new AccountingContext())
            {
                context.Invoices.Remove(invoice);
                var saved = await context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}