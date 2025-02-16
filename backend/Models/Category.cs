namespace coinly.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Activity { get; set; }
    public float Assigned { get; set; }
    public float Available => Assigned - Activity;
    public int AccountId { get; set; }
    public Account Account { get; set; }
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
        id = category.Id;
        name = category.Name;
        assigned = category.Assigned;
        activity = category.Activity;
        available = category.Available;
    }
}

public class AddCategoryInput
{
    public string name { get; set; }
    public int accountId { get; set; }
}

public class UpdateCategoryInput
{
    public int id { get; set; }
    public string name { get; set; }
    public float assigned { get; set; }
    public float activity { get; set; }
}