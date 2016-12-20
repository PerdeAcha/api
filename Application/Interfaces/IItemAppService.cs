using Domain.Entities;

namespace Application.Interfaces
{
    public interface IItemAppService : IAppServiceBase<Item>
    {
        void CreateItem(Item item);
    }
}
