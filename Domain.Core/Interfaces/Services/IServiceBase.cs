using eVendas.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IServiceBase<TKey, TEntity> where TKey : struct where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> AddAsync(TEntity data);
        Task<TEntity> GetItem(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity data);
    }
}
