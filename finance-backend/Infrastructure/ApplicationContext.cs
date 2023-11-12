using finance_backend.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace finance_backend.DataAccess.Models;

public class ApplicationContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
            
    }
    
    public DbSet<Balance> balances { get; set; }
    
    public DbSet<Category> categories { get; set; }
    
    public DbSet<Expense> expenses { get; set; }
    
    public DbSet<Income> incomes { get; set; }
    
    public DbSet<User> users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IncomeConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BalanceConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}