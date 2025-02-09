using coinly.Models;
using HotChocolate;

namespace coinly.GraphQL.Resolvers;

public class Query
{
    public Account GetAccountById(int id, [Service] ApplicationDbContext context)
    {
        try
        {
            return context.Accounts.First(account => account.id == id);
        }
        catch (Exception ex)
        {
            throw new GraphQLException(new Error("Unexpected Execution Error", ex.Message));
        }
    }

    public IEnumerable<Transaction> GetTransactions(int accountId, [Service] ApplicationDbContext context)
    {
        try
        {
            return context.Transactions.Where(transaction => transaction.accountId == accountId).ToList();
        }
        catch (Exception ex)
        {
            throw new GraphQLException(new Error("Unexpected Execution Error", ex.Message));
        }
    }
}