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

public class AddCategoryPayload
{
    public int id { get; set; }
    public string name { get; set; }
    public float assigned { get; set; }
    public float activity { get; set; }
    public float available { get; set; }

    public AddCategoryPayload(Category category)
    {
        id = category.id;
        name = category.name;
        assigned = category.assigned;
        activity = category.activity;
        available = category.available;
    }
}

public class AddCategoryInput
{
    public string name { get; set; }
    public int accountId { get; set; }
}