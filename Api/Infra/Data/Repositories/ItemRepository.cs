using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Api.Infra.Data.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public void CreateItem(Item item)
        {
            Db.Item.Add(item);
        }

        public IEnumerable<Item> GetItemsByTitle(string title)
        {
            return Db.Item.Where(p => p.Title.Contains(title));
        }
    }
}
