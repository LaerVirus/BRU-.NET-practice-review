using BuildShopDataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BuildShopDataAccessLayer.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BuildShopContext _context;

        public OrderRepository(BuildShopContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Order entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.Orders.Add(entity);

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public async Task<bool> Delete(Guid id)
        {
            _context.Orders.Remove(await GetById(id));

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Order entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.Orders.Update(entity);

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
