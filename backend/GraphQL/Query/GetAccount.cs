using coinly.Models;

namespace coinly.GraphQL.Query;

public class GetAccount
{
    public Account GetAccountById(int id)
    {
        return new Account
        {
            id = id,
            income = 10000,
            expense = 6000,
            balance = 4000
        };
    }
}