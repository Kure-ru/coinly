using coinly.Models;

namespace coinly.GraphQL.Mutation;

public class Mutation
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

   public AddCategoryPayload AddCategory([Service] ApplicationDbContext context, int accountId, string name)
   {
       var account = context.Accounts.Find(accountId);
       if (account == null)
       {
           throw new GraphQLException(new Error("Account not found"));
       }
       
       var category = new Category
       {
           name = name,
           activity = 0,
           assigned = 0,
           account = context.Accounts.Find(accountId)
       };

       context.Categories.Add(category);
       context.SaveChanges();
         return new AddCategoryPayload(category);
   }
}