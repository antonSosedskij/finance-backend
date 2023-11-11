using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace finance_backend.DataAccess.Models;

public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
{
    public void Configure(EntityTypeBuilder<Balance> builder)
    {
        builder.ToTable("balances");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("id");
        builder.Property(e => e.Percent)
            .IsRequired()
            .HasColumnName("percent");
        builder.Property(e => e.Id)
            .IsRequired()
            .HasColumnName("categoryId");
        
    }
}