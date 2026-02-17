using Finanzas1.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Finanzas1.Data
{
    public class FinanceContext : DbContext
    {
        public DbSet<Transaction> Transactions => Set<Transaction>();

        public FinanceContext(DbContextOptions<FinanceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);
        }
    }
}
