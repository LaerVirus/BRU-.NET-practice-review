using BuildShopDataAccessLayer;
using BuildShopDataAccessLayer.Repositories;

namespace BuildShopBusinessAccessLayer
{

	public class OrderedItemService : IOrderedItemService
    {
        private readonly IOrderedItemRepository _orderedItemRepository;

        public OrderedItemService(IOrderedItemRepository orderedItemRepository)
        {
            _orderedItemRepository = orderedItemRepository;
        }

		public async Task<IEnumerable<OrderedItem>> GetAll()
		{
			return await _orderedItemRepository.GetAll();
		}

		public async Task<OrderedItem> GetById(Guid id)
		{
			var data = _orderedItemRepository.GetById(id);
			if (data == null)
			{
				throw new Exception("Invalid id");
			}
			return await data;
		}

		public async Task<bool> Create(OrderedItem entity)
		{
			return await _orderedItemRepository.Create(entity);
		}

		public async Task<bool> Delete(Guid id)
		{
			return await _orderedItemRepository.Delete(id);
		}

		public async Task<bool> Update(OrderedItem entity)
		{
			return await _orderedItemRepository.Update(entity);
		}
	}
}
