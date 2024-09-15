namespace DotNetHW2;

public abstract class Item
{
    public static List<Item> Items { get; set; } = new List<Item>();
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public Type Type { get; set; }
}