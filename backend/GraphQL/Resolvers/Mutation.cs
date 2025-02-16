using coinly.Models;

namespace coinly.GraphQL.Mutation;

public class Mutation
{
   public AddTransactionPayload AddTransaction([Service] ApplicationDbContext context, AddTransactionInput input)
   {
       
       var category = context.Categories.FirstOrDefault(category => category.Id == input.categoryId);
       
       if (category == null)
       {
           throw new GraphQLException(new Error("Category not found"));
       }
         
       var transaction = new Transaction
       {
           AccountId = input.accountId,
           Amount = input.amount,
           Category = category,
           Payee = input.payee,
           Date = input.date,
           Type = input.type
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
           Name = name,
           Activity = 0,
           Assigned = 0,
           Account = account
       };

       context.Categories.Add(category);
       context.SaveChanges();
         return new AddCategoryPayload(category);
   }
   
   public string DeleteCategories([Service] ApplicationDbContext context, int[] categoryIds)
   {
       try
       {
           var categories = context.Categories.Where(category => categoryIds.Contains(category.Id)).ToList();
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
           
           category.Name = input.name;
           category.Activity = input.activity;
           category.Assigned = input.assigned;
           
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