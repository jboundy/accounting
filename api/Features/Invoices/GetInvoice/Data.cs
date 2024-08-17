using Accounting.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Features.Invoices.GetInvoice
{
    public class Data
    {
        internal static async Task<Response?> GetInvoice(int id)
        {
            using (var context = new AccountingContext())
            {
                var result = await context.Invoices.SingleOrDefaultAsync(x => x.id == id);

                return new Response
                {
                    invoice = result
                };
            }
        }
    }
}