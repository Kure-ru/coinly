using coinly.Models;

namespace coinly.GraphQL.Query;

public class GetAccount
{
    private readonly ApplicationDbContext _context;
    
    public GetAccount(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Account GetAccountById(int id)
    {
        return _context.Accounts.FirstOrDefault(account => account.id == id);
    }
}