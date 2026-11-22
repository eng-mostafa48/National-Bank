

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

            builder.HasData(
                  new Branch
                  {
                      Code = "BR001",
                      Name = "Tanta Main Branch",
                      Address = "Tanta, Gharbia",
                      PhoneNumber = "0401234567",
                      ManagerId = 1
                  },
                  new Branch
                  {
                      Code = "BR002",
                      Name = "Cairo Branch",
                      Address = "Cairo",
                      PhoneNumber = "0223456789",
                      ManagerId = 2
                  },
                  new Branch
                  {
                      Code = "BR003",
                      Name = "Alexandria Branch",
                      Address = "Alexandria",
                      PhoneNumber = "0345678901",
                      ManagerId = 3
                  }
            );
        }
    }
}
