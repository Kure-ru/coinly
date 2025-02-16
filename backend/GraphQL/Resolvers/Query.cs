using coinly.Models;
using Microsoft.EntityFrameworkCore;

namespace coinly.GraphQL.Resolvers;

public class Query
{
    public Account GetAccountById(int id, [Service] ApplicationDbContext context)
    {
        var account = context.Accounts
            .Include(a => a.Categories)
            .FirstOrDefault(account => account.id == id);
        if (account == null)
        {
            throw new GraphQLException(new Error("Account not found"));
        }
        return account;
    }

    public IEnumerable<Transaction> GetTransactions(int accountId, [Service] ApplicationDbContext context)
    {
        try
        { 
            var transactions = context.Transactions
                .Where(transaction => transaction.AccountId == accountId)
                .Include(t => t.Category)
                .ToList();
            
            return transactions;
        }
        catch (Exception ex)
        {
            throw new GraphQLException(new Error("Unexpected Execution Error", ex.Message));
        }
    }
    
    public IEnumerable<Category> GetCategoriesByAccount(int accountId, [Service] ApplicationDbContext context)
    {
        try
        {
            return  context.Categories.Where(category => category.AccountId == accountId).ToList();
        }
        catch (Exception ex)
        {
            throw new GraphQLException(new Error("Unexpected Execution Error", ex.Message));
        }
    }
}