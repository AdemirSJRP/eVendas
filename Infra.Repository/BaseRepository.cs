using eVendas.Domain.Core.Entities;
using eVendas.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eVendas.Infra.Repository
{
    public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TKey : struct where TEntity : BaseEntity<TKey>
    {
        private readonly protected RepositoryContext _context;
        private readonly protected DbSet<TEntity> _dbSet;

        public BaseRepository(RepositoryContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity data)
        {
            _dbSet.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Task.FromResult<IEnumerable<TEntity>>(_dbSet.AsNoTracking());

        public async Task<TEntity> GetItem(TKey id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(i => i.Id.Equals(id));

        public async Task<TEntity> UpdateAsync(TEntity data)
        {
            if (await _dbSet.FirstOrDefaultAsync(i => i.Id.Equals(data.Id)) == null) return null;
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return data;
        }
    }
}
