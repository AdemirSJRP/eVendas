using eVendas.Domain.Core.Entities;
using eVendas.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceBaseCrud<TKey, TEntity> : IServiceBase<TKey, TEntity> where TKey : struct where TEntity : BaseEntity<TKey>
    {
        private readonly protected IBaseRepository<TKey, TEntity> _repository;

        public ServiceBaseCrud(IBaseRepository<TKey, TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> AddAsync(TEntity data)
        {
            await _repository.AddAsync(data);
            return data;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _repository.GetAllAsync();

        public virtual async Task<TEntity> GetItem(TKey id) => await _repository.GetItem(id);

        public virtual async Task<TEntity> UpdateAsync(TEntity data) => await _repository.UpdateAsync(data);
    }
}
