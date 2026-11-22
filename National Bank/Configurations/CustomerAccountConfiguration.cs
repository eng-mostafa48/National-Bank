

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using National_Bank.Models;

namespace National_Bank.Configurations 
{
    internal class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> builder)
        {
            builder.HasKey(CA => new 
            { 
                CA.CustomerId, CA.AccountNumber 
            });

            builder.HasOne(CA => CA.Account)
                .WithMany(Acc => Acc.AccountCustomers)
                .HasForeignKey(CA => CA.AccountNumber);

            builder.HasOne(CA => CA.Customer)
               .WithMany(C => C.CustomerAccounts)
               .HasForeignKey(CA => CA.CustomerId);
        }
    }
}
