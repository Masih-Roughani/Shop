namespace DotNetHW2;

public abstract class Item
{
    public static List<Item> Items { get; set; } = new List<Item>();
    public virtual string? Name { get; set; }
    public virtual double Price { get; set; }
    public virtual int Quantity { get; set; }
    public Type Type { get; set; }
}