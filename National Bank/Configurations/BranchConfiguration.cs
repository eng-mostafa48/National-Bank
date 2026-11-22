

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using National_Bank.Models;

namespace National_Bank.Configurations
{
    internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(B => B.Code);

            builder.HasOne(b => b.Manager)
                   .WithOne(m => m.Branch)
                   .HasForeignKey<Branch>(b => b.ManagerId);

        }
    }
}
