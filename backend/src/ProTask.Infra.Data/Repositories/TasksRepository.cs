using ProTask.Domain.Interfaces;
using ProTask.Infra.Data.Context;
using ProTask.Infra.Data.Repositories.Base;

namespace ProTask.Infra.Data.Repositories
{
    public class TasksRepository : IntRepository<Domain.Models.Task>, ITaskRepository
    {
        public TasksRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}