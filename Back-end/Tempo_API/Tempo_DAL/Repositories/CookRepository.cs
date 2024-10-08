using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class CookRepository : GenericRepository<CookEntity>, ICookRepository
{
    public CookRepository(TempoDbContext dbContext) : base(dbContext) 
    {
    }
}
