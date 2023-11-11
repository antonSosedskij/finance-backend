using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace finance_backend.Data_access.Models;

public class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.ToTable("incomes");
        builder.HasKey(e => e.id);
        builder.Property(e => e.id)
            .ValueGeneratedOnAdd();
        builder.Property(e => e.title).IsRequired();
        builder.HasData(
            new Income
            {
                id = Guid.NewGuid(),
                title = "Покупочки",
                amount = 2000
            }
        );
    }
}