using BuildShopDataAccessLayer;
using BuildShopDataAccessLayer.Repositories;

namespace BuildShopBusinessAccessLayer
{
	public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

		public async Task<IEnumerable<Item>> GetAll()
		{
			return await _itemRepository.GetAll();
		}

		public async Task<Item> GetById(Guid id)
		{
			var data = _itemRepository.GetById(id);
			if (data == null)
			{
				throw new Exception("Invalid id");
			}
			return await data;
		}

		public async Task<bool> Create(Item entity)
		{
			return await _itemRepository.Create(entity);
		}

		public async Task<bool> Delete(Guid id)
		{
			return await _itemRepository.Delete(id);
		}

		public async Task<bool> Update(Item entity)
		{
			return await _itemRepository.Update(entity);
		}
	}
}
