using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application
{
    public class ItemAppService : AppServiceBase<Item>, IItemAppService
    {
        private readonly IItemService _itemService;

        public ItemAppService(IItemService itemService)
            : base(itemService)
        {
            _itemService = itemService;
        }

        public void CreateItem(Item item)
        {
            _itemService.CreateItem(item);
        }
    }
}
