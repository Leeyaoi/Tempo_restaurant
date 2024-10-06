using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class WaiterRepository : GenericRepository<WaiterEntity>, IWaiterRepository
{
    public WaiterRepository(TempoDbContext dbContext) : base(dbContext)
    {
    }
}
