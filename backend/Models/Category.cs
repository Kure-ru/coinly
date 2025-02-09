namespace coinly.Models;

public class Category
{
    public int id { get; set; }
    public string name { get; set; }
    public float activity { get; set; }
    public float assigned { get; set; }
    public float available => assigned - activity;
    public int accountId { get; set; }
    public Account account { get; set; }
}