using coinly.Models;

namespace coinly.GraphQL.Mutation;

public class TransactionMutation
{
   public AddTransactionPayload AddTransaction([Service] ApplicationDbContext context, AddTransactionInput input)
   {
       var transaction = new Transaction
       {
           accountId = input.accountId,
           amount = input.amount,
           category = input.category,
           payee = input.payee,
           date = input.date,
           type = input.type
       };
       
       context.Transactions.Add(transaction);
       context.SaveChanges();
       return new AddTransactionPayload(transaction);
   }
}