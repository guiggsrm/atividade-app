using ProTask.Domain.Interfaces;
using ProTask.Domain.Models;
using ProTask.Infra.Data.Context;
using ProTask.Infra.Data.Repositories.Base;

namespace ProTask.Infra.Data.Repositories
{
    public class ClientRepository : IntRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}