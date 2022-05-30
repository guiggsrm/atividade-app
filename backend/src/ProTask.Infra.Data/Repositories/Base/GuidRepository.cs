using ProTask.Infra.Data.Context;

namespace ProTask.Infra.Data.Repositories.Base
{
    public abstract class GuidRepository<TEntity> : Repository<TEntity, Guid> where TEntity : Domain.Models.Base.Entity
    {
        public GuidRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    }
}