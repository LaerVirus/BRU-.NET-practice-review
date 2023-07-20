using BuildShopDataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BuildShopDataAccessLayer.Implementations
{
    public class OrderedItemRepository : IOrderedItemRepository
    {
        private readonly BuildShopContext _context;

        public OrderedItemRepository(BuildShopContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(OrderedItem entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.OrderedItems.Add(entity);

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public async Task<bool> Delete(Guid id)
        {
            _context.OrderedItems.Remove(await GetById(id));

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public async Task<List<OrderedItem>> GetAll()
        {
            return await _context.OrderedItems.ToListAsync();
        }

        public async Task<OrderedItem> GetById(Guid id)
        {
            return await _context.OrderedItems.FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task<bool> Update(OrderedItem entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.OrderedItems.Update(entity);

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
