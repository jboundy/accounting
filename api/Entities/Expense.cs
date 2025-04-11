using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Entities
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public required int BudgetId { get; set; }
        public required string Category { get; set; }
        public required double Amount { get; set; }
        public required DateTime Date { get; set; }

    }
}