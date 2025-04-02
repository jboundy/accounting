using Accounting.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Api.Context
{
    public class AccountingContext : DbContext
    {
        public AccountingContext(DbContextOptions<AccountingContext> options) : base(options)
        {

        }

        public virtual DbSet<Budget> Budgets { get; set; }

        public virtual DbSet<Expense> Expenses { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}