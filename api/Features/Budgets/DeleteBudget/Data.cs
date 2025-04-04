using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Context;
using Accounting.Api.Entities;

namespace Accounting.Api.Features.Budgets.DeleteBudget
{
    public class Data
    {
        private static AccountingContext _context;

        public Data(AccountingContext context)
        {
            _context = context;
        }

        internal static async Task<Response?> DeleteBudget(Budget budget)
        {
            using (_context)
            {
                _context.Budgets.Remove(budget);
                var saved = await _context.SaveChangesAsync();
                return new Response
                {
                    Saved = saved == 1
                };
            }
        }
    }
}