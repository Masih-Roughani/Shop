using DotNetHW2;

namespace Service;

public interface IItemService
{
    bool Add(Item item);
    bool Delete(Item item);
    bool Purchase(Item item);
}