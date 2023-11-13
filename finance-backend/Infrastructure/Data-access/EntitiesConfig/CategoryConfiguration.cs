using finance_backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace finance_backend.Infrastructure.Data_access.EntitiesConfig;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(e => e.Id)
            .HasColumnName("id");
        builder.Property(e => e.Title)
            .IsRequired()
            .HasColumnName("title");
        builder
            .HasMany(c => c.Balances)
            .WithOne(b => b.Category)
            .HasForeignKey(b => b.CategoryId)
            .IsRequired();
    }
}