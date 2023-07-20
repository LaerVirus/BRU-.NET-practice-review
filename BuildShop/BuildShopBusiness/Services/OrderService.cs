using BuildShopDataAccessLayer;
using BuildShopDataAccessLayer.Repositories;

namespace BuildShopBusinessAccessLayer
{
	public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

		public async Task<IEnumerable<Order>> GetAll()
		{
			return await _orderRepository.GetAll();
		}

		public async Task<Order> GetById(Guid id)
		{
			var data = _orderRepository.GetById(id);
			if (data == null)
			{
				throw new Exception("Invalid id");
			}
			return await data;
		}

		public async Task<bool> Create(Order entity)
		{
			return await _orderRepository.Create(entity);
		}

		public async Task<bool> Delete(Guid id)
		{
			return await _orderRepository.Delete(id);
		}

		public async Task<bool> Update(Order entity)
		{
			return await _orderRepository.Update(entity);
		}
	}
}
