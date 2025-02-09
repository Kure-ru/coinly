using coinly.Models;

namespace coinly.GraphQL.Query;

public class Query
{
    private readonly ApplicationDbContext _context;
    
    public Query(ApplicationDbContext context)
    {
        _context = context;
    }
    public Account GetAccountById(int id) =>
        _context.Accounts.First(account => account.id == id);
    
    public IEnumerable<Transaction> GetTransactions(int accountId) =>
        _context.Transactions.Where(transaction => transaction.accountId == accountId).ToList();
}