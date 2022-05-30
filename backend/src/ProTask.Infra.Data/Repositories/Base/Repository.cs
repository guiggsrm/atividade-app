using Microsoft.EntityFrameworkCore;
using ProTask.Domain.Interfaces.Base;
using ProTask.Infra.Data.Context;

namespace ProTask.Infra.Data.Repositories.Base
{
    public abstract class Repository<TEntity, Key> : IRepository<TEntity, Key> where TEntity : Domain.Models.Base.Entity
    {
        protected readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<TEntity> CreateAsync(TEntity model)
        {
            await _dbContext.Set<TEntity>().AddAsync(model);
            return await SaveAsync(model);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Key id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if(entity != null)
                _dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task RemoveAsync(TEntity model)
        {
            _dbContext.Set<TEntity>().Remove(model);
            await SaveAsync(model);
        }

        public async Task<TEntity> UpdateAsync(TEntity model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            return await SaveAsync(model);
        }
        /// <summary>
        /// Salva todas as alterações na base de dados
        /// </summary>
        private async Task<TEntity> SaveAsync(TEntity model)
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return model;
            }/*
            catch (DbUpdateException e)
            {
                _dbContext.Entry(model).State = EntityState.Unchanged;
                throw;
            }*/
            catch (Exception)
            {
                _dbContext.Entry(model).State = EntityState.Unchanged;
                throw;
            }
        }
    }
}