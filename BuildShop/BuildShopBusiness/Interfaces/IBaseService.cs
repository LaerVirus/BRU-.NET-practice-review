using BuildShopDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildShopBusinessAccessLayer.Interfaces
{
	public interface IBaseService<T>
	{
		Task<IEnumerable<T>> GetAll();
		Task<T> GetById(Guid id);
		Task<bool> Create(T entity);
		Task<bool> Delete(Guid id);
		Task<bool> Update(T entity);
	}
}
