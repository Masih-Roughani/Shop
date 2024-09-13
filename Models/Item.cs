namespace DotNetHW2;

public abstract class Item
{
    public static List<Item> Items { get; set; } = new List<Item>();
    public required string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public Type Type { get; set; }
}

public class GroceryItem : Item
{
    public GroceryItem(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Type = Type.Grocery;
    }
}

public class ElectronicsItem : Item
{
    public ElectronicsItem(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Type = Type.Electronic;
    }
}