using coinly.Models;

namespace coinly.GraphQL.Query;

public class GetTransactions
{
    private readonly ApplicationDbContext _context;

    public GetTransactions(ApplicationDbContext context)
    {
        _context = context;
    }

    public Transaction[] GetAllTransactionByAccount(int accountId)
    {
        return _context.Transactions.Where(transaction => transaction.accountId == accountId).ToArray();
    }
}
