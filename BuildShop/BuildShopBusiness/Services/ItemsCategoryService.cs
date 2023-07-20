using BuildShopDataAccessLayer;
using BuildShopDataAccessLayer.Repositories;

namespace BuildShopBusinessAccessLayer
{
	public class ItemsCategoryService : IItemsCategoryService
    {
        private readonly IItemsCategoryRepository _itemsCategoryRepository;

        public ItemsCategoryService(IItemsCategoryRepository itemsCategoryRepository)
        {
            _itemsCategoryRepository = itemsCategoryRepository;
        }

		public async Task<IEnumerable<ItemsCategory>> GetAll()
		{
			return await _itemsCategoryRepository.GetAll();
		}

		public async Task<ItemsCategory> GetById(Guid id)
		{
			var data = _itemsCategoryRepository.GetById(id);
			if (data == null)
			{
				throw new Exception("Invalid id");
			}
			return await data;
		}

		public async Task<bool> Create(ItemsCategory entity)
		{
			return await _itemsCategoryRepository.Create(entity);
		}

		public async Task<bool> Delete(Guid id)
		{
			return await _itemsCategoryRepository.Delete(id);
		}

		public async Task<bool> Update(ItemsCategory entity)
		{
			return await _itemsCategoryRepository.Update(entity);
		}
	}
}
