using finance_backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace finance_backend.DataAccess.Models;

public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
{
    public void Configure(EntityTypeBuilder<Balance> builder)
    {
        builder.ToTable("balances");
        builder.HasKey(e => e.Id);
        builder
            .Property(e => e.Title)
            .IsRequired();
        builder.Property(e => e.Percent)
            .IsRequired()
            .HasColumnName("percent");
        builder.Property(e => e.CategoryId)
            .IsRequired();
        builder
            .HasOne(u => u.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .HasPrincipalKey(u => u.Id);

    }
}