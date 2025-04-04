using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Budgets.CreateBudget
{
    public class Data
    {
        private static AccountingContext _context;

        public Data(AccountingContext context)
        {
            _context = context;
        }
        internal static async Task<Response?> CreateBudget(Budget obj)
        {
            using (_context)
            {
                var result = await _context.Budgets.AddAsync(obj);
                var saved = await _context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}