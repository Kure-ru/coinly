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
    }
}