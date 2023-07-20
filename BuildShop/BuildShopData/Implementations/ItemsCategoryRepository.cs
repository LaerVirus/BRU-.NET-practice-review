using BuildShopDataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BuildShopDataAccessLayer.Implementations
{
    public class ItemsCategoryRepository : IItemsCategoryRepository
    {
        private readonly BuildShopContext _context;

        public ItemsCategoryRepository(BuildShopContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(ItemsCategory entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.ItemsCategories.Add(entity);

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public async Task<bool> Delete(Guid id)
        {
            _context.ItemsCategories.Remove(await GetById(id));

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

		public async Task<List<ItemsCategory>> GetAll()
        {
            return await _context.ItemsCategories.ToListAsync();
        }

        public async Task<ItemsCategory> GetById(Guid id)
        {
            return await _context.ItemsCategories.FirstOrDefaultAsync(x => x.Id == id);
        }


		public async Task<bool> Update(ItemsCategory entity)
        {
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _context.ItemsCategories.Update(entity);

            return await Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
