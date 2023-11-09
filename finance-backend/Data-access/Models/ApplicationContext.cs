using Microsoft.EntityFrameworkCore;

namespace finance_backend.Data_access.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
            
    }
    
    public DbSet<Balance> balances { get; set; }
    
    public DbSet<Category> categories { get; set; }
    
    public DbSet<Expense> expenses { get; set; }
    
    public DbSet<Income> incomes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IncomeConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BalanceConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}