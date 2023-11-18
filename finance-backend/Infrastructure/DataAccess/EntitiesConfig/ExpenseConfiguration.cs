using finance_backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace finance_backend.DataAccess.Models;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("expenses");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .IsRequired()
            .HasColumnName("id");
        builder.Property(e => e.Title)
            .IsRequired()
            .HasColumnName("title");
        builder.Property(e => e.BalanceId)
            .IsRequired()
            .HasColumnName("balanceId");
        builder
            .HasOne(e => e.Balance)
            .WithMany(b => b.Expenses)
            .HasForeignKey(e => e.BalanceId);
    }
}