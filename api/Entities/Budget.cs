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

        public List<LineItem> LineItems { get; set; }

        public double SumLineItemAmounts()
        {
            return LineItems.Sum(x => x.Amount);
        }

    }

    public class LineItem
    {
        public string Name { get; set; }
        public double Amount { get; set; }
    }
}