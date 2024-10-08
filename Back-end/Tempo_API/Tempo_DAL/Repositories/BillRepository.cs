using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class BillRepository :GenericRepository<BillEntity>, IBillRepository
{
    public BillRepository(TempoDbContext dbcontext) : base(dbcontext) 
    {
    }
}
