using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IItemAppService : IAppServiceBase<Item>
    {
        void CreateItem(Item item);
        IEnumerable<Item> GetItemsByTitle(string title);
    }
}
