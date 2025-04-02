using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Entities
{
    public class Budget
    {
        public int Id { get; set; }

        public double ExpectedAmountToSpend { get; set; }

        public ICollection<Transactions>? Transactions { get; set; }

        public double SumTransactions(bool isCredit)
        {
            if (Transactions.Count() == 0)
            {
                return 0;
            }

            var transactions = Transactions.Where(x => x.IsCredit == isCredit).ToList();
            return transactions.Sum(x => x.Amount);
        }
    }
}