using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IItemService : IServiceBase<Item>
    {
         void CreateItem(Item item);
    }
}
