namespace coinly.Models;

public class Transaction
{
    public int id { get; set; }
    public int accountId { get; set; }
    public float amount { get; set; }
    public string category { get; set; }
    public string merchant { get; set; }
}