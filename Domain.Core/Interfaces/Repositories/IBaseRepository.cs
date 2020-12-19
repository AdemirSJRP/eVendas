using eVendas.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eVendas.Domain.Core.Interfaces.Repositories
{
    public interface IBaseRepository<Tkey, TEntity> where Tkey : struct where TEntity : BaseEntity<Tkey>
    {
        Task<TEntity> AddAsync(TEntity data);
        Task<TEntity> GetItem(Tkey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity data);
    }
}
