using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Features.Budgets.GetBudget
{
    public class Data
    {
        private static AccountingContext _context;

        public Data(AccountingContext context)
        {
            _context = context;
        }
        internal static async Task<Response?> GetBudget(int id)
        {
            using (_context)
            {
                var result = await _context.Budgets.SingleOrDefaultAsync(x => x.Id == id);

                return new Response
                {
                    Budget = result
                };
            }
        }
    }
}