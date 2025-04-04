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
        private static AccountingContext _context;
        public Data(AccountingContext context)
        {
            _context = context;
        }
        internal static async Task<Response?> SendInvoice(Invoice obj)
        {
            using (_context)
            {
                var result = _context.Invoices.Update(obj);
                var saved = await _context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}