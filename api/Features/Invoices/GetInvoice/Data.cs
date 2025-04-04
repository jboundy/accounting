using Accounting.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Features.Invoices.GetInvoice
{
    public class Data
    {
        private static AccountingContext _context;
        public Data(AccountingContext context)
        {
            _context = context;
        }
        internal static async Task<Response?> GetInvoice(int id)
        {
            using (_context)
            {
                var result = await _context.Invoices.SingleOrDefaultAsync(x => x.Id == id);

                return new Response
                {
                    Invoice = result
                };
            }
        }
    }
}