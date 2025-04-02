using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Invoices.SendInvoice
{
    public class Data
    {
        internal static async Task<Response?> SendInvoice(AccountingContext context, Invoice obj)
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