namespace DotNetHW2.Items;

public sealed class GroceryItem : Item
{
    public GroceryItem(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Type = Type.Grocery;
        Items.Add(this);
    }
}