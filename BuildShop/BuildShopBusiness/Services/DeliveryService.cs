using BuildShopDataAccessLayer;
using BuildShopDataAccessLayer.Repositories;

namespace BuildShopBusinessAccessLayer
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<IEnumerable<Delivery>> GetAll()
        {
            return await _deliveryRepository.GetAll();
        }

        public async Task<Delivery> GetById(Guid id)
        {
			var data = _deliveryRepository.GetById(id);
			if (data == null)
			{
				throw new Exception("Invalid id");
			}
			return await data;
		}

		public async Task<bool> Create(Delivery entity)
		{
			return await _deliveryRepository.Create(entity);
		}

		public async Task<bool> Delete(Guid id)
		{
			return await _deliveryRepository.Delete(id);
		}

		public async Task<bool> Update(Delivery entity)
		{
			return await _deliveryRepository.Update(entity);
		}
	}
}
