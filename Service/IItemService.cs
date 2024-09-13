using DotNetHW2;

namespace Service;

public interface IItemService
{
    void Add(Item item);
    bool Delete(Item item);
    bool Purchase(Item item);
}