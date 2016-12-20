using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IItemService : IServiceBase<Item>
    {
         void CreateItem(Item item);
         IEnumerable<Item> GetItemsByTitle(string title);
    }
}
