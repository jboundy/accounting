using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Entities
{
    public class Transactions
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public bool IsCredit { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}