using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Entities
{
    public class Budget
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public double ExpectedAmountToSpend { get; set; }

        public ICollection<Expense>? Expenses { get; set; } = null;

        public double ActualAmountSpent => SumExpenses();

        public double SumExpenses()
        {
            return Expenses?.Sum(x => x.Amount) ?? 0;
        }
    }
}