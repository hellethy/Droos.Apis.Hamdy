using Droos.Model.Context;
using Droos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Droos.Repositories
{
    public class RepoBase<T> : IRepoBase<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        public AppDbContext DbContext { get; }


        public RepoBase(AppDbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            _dbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
