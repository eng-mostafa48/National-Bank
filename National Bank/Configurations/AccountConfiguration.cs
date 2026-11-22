

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using National_Bank.Models;

namespace National_Bank.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(Acc => Acc.AccountNumber);

            builder.HasOne(Acc => Acc.CreatedAtBranch)
                   .WithMany(B => B.Accounts)
                   .HasForeignKey(B => B.CreatedAtBranchCode);


        }
    }
}
