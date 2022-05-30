namespace ProTask.Domain.Interfaces.Base
{
    public interface IRepository<TEntity, Key>
    {
        Task<TEntity> CreateAsync(TEntity model);
        Task<TEntity> UpdateAsync(TEntity model);
        Task RemoveAsync(TEntity model);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity?> GetAsync(Key id);
    }
}