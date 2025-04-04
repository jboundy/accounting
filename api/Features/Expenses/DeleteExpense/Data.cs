using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Expenses.DeleteExpense
{
    public class Data
    {
        private static AccountingContext _context;
        public Data(AccountingContext context)
        {
            _context = context;
        }
        internal static async Task<Response?> DeleteExpense(Expense obj)
        {
            using (_context)
            {
                _context.Expenses.Remove(obj);
                var saved = await _context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}