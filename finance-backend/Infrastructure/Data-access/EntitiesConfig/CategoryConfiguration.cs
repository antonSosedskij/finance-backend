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
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId);
    }
}