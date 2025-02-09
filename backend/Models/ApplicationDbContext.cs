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

        modelBuilder.Entity<Transaction>().HasData(
            new Transaction
            {
                id = 1, accountId = 1, amount = 1000, category = "rent", payee = "landlord",
                date = new DateTime(2025, 1, 1), type = TransactionType.outflow
            },
            new Transaction
            {
                id = 2, accountId = 1, amount = 2000, category = "groceries", payee = "monoprix",
                date = new DateTime(2025, 1, 2), type = TransactionType.outflow
            },
            new Transaction
            {
                id = 3, accountId = 2, amount = 3000, category = "rent", payee = "landlord",
                date = new DateTime(2025, 1, 3), type = TransactionType.outflow
            },
            new Transaction
            {
                id = 4, accountId = 2, amount = 4000, category = "groceries", payee = "monoprix",
                date = new DateTime(2025, 1, 4), type = TransactionType.outflow
            },
            new Transaction
            {
                id = 5, accountId = 3, amount = 5000, category = "rent", payee = "landlord",
                date = new DateTime(2025, 1, 5), type = TransactionType.outflow
            },
            new Transaction
            {
                id = 6, accountId = 1, amount = 6000, category = "salary", payee = "employer",
                date = new DateTime(2025, 1, 1), type = TransactionType.inflow
            });
        
        modelBuilder.Entity<Category>().HasData(
            new Category { id = 1, name = "rent", activity = 1000, assigned = 1000, accountId = 1},
            new Category { id = 2, name = "groceries", activity = 2000, assigned = 2000, accountId = 1},
            new Category { id = 3, name = "rent", activity = 3000, assigned = 3000, accountId = 2},
            new Category { id = 4, name = "groceries", activity = 4000, assigned = 4000, accountId = 2},
            new Category { id = 5, name = "rent", activity = 5000, assigned = 5000, accountId = 3});
    }
    
    
}