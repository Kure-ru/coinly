using System.ComponentModel.DataAnnotations;

namespace coinly.Models;

public class Transaction
{
    public int id { get; set; }
    public int accountId { get; set; }
    public float amount { get; set; }
    [MaxLength(100)]
    public string? category { get; set; }
    [MaxLength(100)]
    public string? payee { get; set; }
    public DateTime date { get; set; }
    public TransactionType type { get; set; }
}

public class AddTransactionInput
{
    public int accountId { get; set; }
    public float amount { get; set; }
    public string? category { get; set; }
    public string? payee { get; set; }
    public DateTime date { get; set; }
    public TransactionType type { get; set; }
}

public class AddTransactionPayload
{
    public int id { get; set; }
    public float amount { get; set; }
    public string? category { get; set; }
    public string? payee { get; set; }
    public DateTime date { get; set; }
    public TransactionType type { get; set; }

    public AddTransactionPayload(Transaction transaction)
    {
        id = transaction.id;
        amount = transaction.amount;
        category = transaction.category;
        payee = transaction.payee;
        date = transaction.date;
        type = transaction.type;
    }
}


