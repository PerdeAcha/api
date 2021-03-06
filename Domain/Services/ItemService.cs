using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ItemService : ServiceBase<Item>, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
            : base(itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void CreateItem(Item item)
        {
            _itemRepository.Add(item);
        }

        public IEnumerable<Item> GetItemsByTitle(string title)
        {
            return _itemRepository.GetItemsByTitle(title);
        }
    }
}
