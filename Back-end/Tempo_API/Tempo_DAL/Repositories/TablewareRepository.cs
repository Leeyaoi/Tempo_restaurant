using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class TablewareRepository : GenericRepository<TablewareEntity>, ITablewareRepository
{
    public TablewareRepository(TempoDbContext dbContext) : base(dbContext)
    {
    }
}
