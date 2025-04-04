using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Expenses.CreateExpense
{
    public class Data
    {
        private static AccountingContext _context;
        public Data(AccountingContext context)
        {
            _context = context;
        }
        internal static async Task<Response?> CreateExpense(Expense obj)
        {
            using (_context)
            {
                var result = await _context.Expenses.AddAsync(obj);
                var saved = await _context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}