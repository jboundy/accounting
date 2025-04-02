using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Api.Entities
{
    public class Expense
    {
        public int Id { get; set; }

        public required string Category { get; set; }
    }
}