namespace DotNetHW2;

public class ElectronicsItem : Item
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