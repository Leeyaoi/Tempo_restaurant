using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class TablewareDishRepository : GenericRepository<TablewareDishEntity>, ITablewareDishRepository
{
    public TablewareDishRepository(TempoDbContext dbContext) : base(dbContext)
    {
    }
}
