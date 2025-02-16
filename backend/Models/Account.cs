namespace coinly.Models;

public class Account
{
    public int id { get; set; }
    public float income { get; set; }
    public float expense => CalculateExpense();
    public float balance => income - expense;
    public List<Category> Categories { get; set; } = new();
    
    private float CalculateExpense()
    {
        if (Categories == null || !Categories.Any())
        {
            Console.WriteLine("Categories list is empty or null.");
            return 0;
        }
        return Categories.Sum(category => category.Activity);
    }
    
}