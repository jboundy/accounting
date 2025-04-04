using Accounting.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Features.Expenses.GetExpense
{
    public class Data
    {
        private static AccountingContext _context;
        public Data(AccountingContext context)
        {
            _context = context;
        }
        internal static async Task<Response?> GetExpense(int id)
        {
            using (_context)
            {
                var result = await _context.Expenses.SingleOrDefaultAsync(x => x.Id == id);

                return new Response
                {
                    Expense = result
                };
            }
        }
    }
}