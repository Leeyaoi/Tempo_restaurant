using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class TableRepository : GenericRepository<TableEntity>, ITableRepository
{
    public TableRepository(TempoDbContext dbContext) : base(dbContext)
    {
    }
}
