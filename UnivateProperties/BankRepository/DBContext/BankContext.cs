using BankRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace BankRepository.DBContext
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().HasData(
                new Bank
                {
                    Id = 1,
                    Name = "FNB"
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
