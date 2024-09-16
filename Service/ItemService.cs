using DotNetHW2;
using DotNetHW2.Items;
using DotNetHW2.Users;
using Type = DotNetHW2.Type;

namespace Service;

public class ItemService : IItemService
{
    public static User User { get; set; }

    public bool Add(string name, double price, int quantity, string itemType)
    {
        Item? item;
        if (itemType == Type.Electronic.ToString())
        {
            item = new ElectronicsItem(name, price, quantity);
            Item.Items.Add(item);
            return true;
        }
        else if (itemType == Type.Grocery.ToString())
        {
            item = new GroceryItem(name, price, quantity);
            Item.Items.Add(item);
            return true;
        }

        return false;
    }

    public bool Delete(string name)
    {
        foreach (var item in Item.Items.Where(item => item.Name == name))
        {
            Item.Items.Remove(item);
            return true;
        }

        return false;
    }

    public bool Purchase(string name)
    {
        var item = Item.Items.FirstOrDefault(item => item.Name == name)!;
        if (!(((NonAdmin)User).Money >= item.Price) || item.Quantity == 0) return false;
        ((NonAdmin)User).Money -= item.Price;
        item.Quantity -= 1;
        return true;
    }
}