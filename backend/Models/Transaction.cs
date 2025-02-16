using System.ComponentModel.DataAnnotations;

namespace coinly.Models;

public class Transaction
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public float Amount { get; set; }
    public Category Category { get; set; }
    [MaxLength(100)]
    public string? Payee { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
}

public class AddTransactionInput
{
    public int accountId { get; set; }
    public float amount { get; set; }
    public int categoryId { get; set; }
    public string? payee { get; set; }
    public DateTime date { get; set; }
    public TransactionType type { get; set; }
}

public class AddTransactionPayload
{
    public int id { get; set; }
    public float amount { get; set; }
    public Category category { get; set; }
    public int CategoryId { get; set; }
    public string? payee { get; set; }
    public DateTime date { get; set; }
    public TransactionType type { get; set; }

    public AddTransactionPayload(Transaction transaction)
    {
        id = transaction.Id;
        amount = transaction.Amount;
        category = transaction.Category;
        CategoryId = transaction.Category.Id;
        payee = transaction.Payee;
        date = transaction.Date;
        type = transaction.Type;
    }
}


