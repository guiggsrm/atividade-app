using ProTask.Infra.Data.Context;

namespace ProTask.Infra.Data.Repositories.Base
{
    public abstract class IntRepository<TEntity> : Repository<TEntity, int> where TEntity : Domain.Models.Base.Entity
    {
        public IntRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    }
}