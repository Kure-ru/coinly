using coinly.Models;
using Microsoft.EntityFrameworkCore;

namespace coinly;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>().HasData(
            new Account { id = 1, income = 10000, expense = 6000, balance = 4000 },
            new Account { id = 2, income = 20000, expense = 10000, balance = 10000 },
            new Account { id = 3, income = 30000, expense = 20000, balance = 10000 });

        modelBuilder.Entity<Transaction>().HasData(
            new Transaction { id = 1, accountId = 1, amount = 1000, category = "rent", merchant = "landlord" },
            new Transaction { id = 2, accountId = 1, amount = 2000, category = "groceries", merchant = "monoprix" },
            new Transaction { id = 3, accountId = 1, amount = 3000, category = "salary", merchant = "employer" },
            new Transaction { id = 4, accountId = 2, amount = 4000, category = "rent", merchant = "landlord" },
            new Transaction { id = 5, accountId = 2, amount = 5000, category = "groceries", merchant = "monoprix" });

    }
}