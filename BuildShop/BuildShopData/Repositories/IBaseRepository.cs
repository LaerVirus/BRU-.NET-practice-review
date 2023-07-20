using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildShopDataAccessLayer.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Update(T entity);
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
    }
}
