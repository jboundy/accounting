using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Account.Api.Features.Invoices.SendInvoice
{
    public class Data
    {
        internal static async Task<Response?> SendInvoice(Invoice obj)
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