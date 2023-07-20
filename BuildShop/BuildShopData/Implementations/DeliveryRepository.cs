using BuildShopDataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BuildShopDataAccessLayer.Implementations
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly BuildShopContext _context;

        public DeliveryRepository(BuildShopContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Delivery entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.Deliveries.Add(entity);

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public async Task<bool> Delete(Guid id)
        {
            _context.Deliveries.Remove(await GetById(id));

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public async Task<List<Delivery>> GetAll()
        {
            return await _context.Deliveries.ToListAsync();
        }

        public async Task<Delivery> GetById(Guid id)
        {
            return await _context.Deliveries.FirstOrDefaultAsync(x => x.OrderedId == id);
        }

        public async Task<bool> Update(Delivery entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

			_context.Deliveries.Update(entity);

			return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
