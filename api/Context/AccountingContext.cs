using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Context
{
    public class AccountingContext : DbContext
    {
        public AccountingContext(DbContextOptions<AccountingContext> options) : base(options)
        {

        }

        public AccountingContext() : base()
        {

        }
        public virtual DbSet<Expense> Expenses { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }


    }
}