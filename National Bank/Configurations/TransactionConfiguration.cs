

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using National_Bank.Models;


namespace National_Bank.Configurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(T=>T.TransactionNumber);

            builder.HasOne(T => T.Account)
                .WithMany(Acc => Acc.Transactions)
                .HasForeignKey(T => T.AccountNumber);
        }
    }
}
