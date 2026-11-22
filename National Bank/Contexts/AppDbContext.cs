

using Microsoft.EntityFrameworkCore;
using National_Bank.Models;

namespace National_Bank.Contexts
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=NationalBank;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly
                (typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Manager>().HasData(
                new Manager
                {
                    Id = 1,
                    FullName = "Ahmed Mohamed",
                    Email = "ahmed@bank.com",
                    PhoneNumber = "01012345678",
                    HireDate = new DateTime(2020, 1, 15)
                },
                new Manager
                {
                    Id = 2,
                    FullName = "Sara Ali",
                    Email = "sara@bank.com",
                    PhoneNumber = "01098765432",
                    HireDate = new DateTime(2021, 3, 10)
                },
                new Manager
                {
                    Id = 3,
                    FullName = "Omar Hassan",
                    Email = "omar@bank.com",
                    PhoneNumber = "01112345678",
                    HireDate = new DateTime(2022, 6, 20)
                }
            );
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts {  get; set; }
    }
}
