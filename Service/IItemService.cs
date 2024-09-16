namespace Service;

public interface IItemService
{
    bool Add(string name, double price, int quantity, string itemType);
    bool Delete(string name);
    bool Purchase(string name);
}