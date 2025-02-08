using coinly.Models;

namespace coinly.GraphQL.Query;

public class Query
{
    public Account GetAccountById(int id, [Service] ApplicationDbContext context) =>
        context.Accounts.First(account => account.id == id);
    
    public IQueryable<Transaction> GetTransactions(int accountId, [Service] ApplicationDbContext context) =>
        context.Transactions.Where(transaction => transaction.accountId == accountId);
}