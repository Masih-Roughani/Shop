namespace DotNetHW2.Items;

public sealed class ElectronicsItem : Item
{
    public ElectronicsItem(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Type = Type.Electronic;
        Items.Add(this);
    }
}