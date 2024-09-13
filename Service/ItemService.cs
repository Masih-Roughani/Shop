using DotNetHW2;

namespace Service;

public class ItemService : IItemService
{
    public static User User { get; set; }

    public void Add(Item item)
    {
        Item.Items.Add(item);
    }

    public bool Delete(Item item)
    {
        if (User is not Admin) return false;
        Item.Items.Remove(item);
        return true;
    }

    public bool Purchase(Item item)
    {
        if (User is not NonAdmin admin || !(admin.Money >= item.Price)) return false;
        admin.Money -= item.Price;
        return true;

    }
}