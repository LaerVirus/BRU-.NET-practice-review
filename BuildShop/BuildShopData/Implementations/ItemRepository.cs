using BuildShopDataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BuildShopDataAccessLayer.Implementations
{
    public class ItemRepository : IItemRepository
    {
        private readonly BuildShopContext _context;

        public ItemRepository(BuildShopContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Item entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.Items.Add(entity);

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public async Task<bool> Delete(Guid id)
        {          
            _context.Items.Remove(await GetById(id));

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public async Task<List<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetById(Guid id)
        {
            return await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Item entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.Items.Update(entity);

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
