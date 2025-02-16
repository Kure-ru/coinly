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
   
   public string DeleteCategories([Service] ApplicationDbContext context, int[] categoryIds)
   {
       try
       {
           var categories = context.Categories.Where(category => categoryIds.Contains(category.id)).ToList();
           context.Categories.RemoveRange(categories);
           context.SaveChanges();
           return "Categories deleted successfully";
       } 
       catch (Exception ex)
       {
              throw new GraphQLException(new Error("Unexpected Execution Error", ex.Message));
       }

   }

   public Category UpdateCategory([Service] ApplicationDbContext context, UpdateCategoryInput input)
   {
       try
       {
           var category = context.Categories.Find(input.id);
           if (category == null)
           {
               throw new GraphQLException(new Error("Category not found."));
           }
           
           category.name = input.name;
           category.activity = input.activity;
           category.assigned = input.assigned;
           
           context.Categories.Update(category);
           context.SaveChanges();
           return category;
       }
       catch (Exception ex)
       {
           throw new GraphQLException(new Error("Unexpected Execution Error", ex.Message));
       }
   }
}