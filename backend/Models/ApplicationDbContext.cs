using coinly.Models;
using Microsoft.EntityFrameworkCore;

namespace coinly;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>().HasData(
            new Account { id = 1, income = 10000},
            new Account { id = 2, income = 20000},
            new Account { id = 3, income = 30000});
    }
    
}