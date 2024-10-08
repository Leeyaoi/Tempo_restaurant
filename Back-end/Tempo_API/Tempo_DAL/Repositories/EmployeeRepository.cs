using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class EmployeeRepository : GenericRepository<EmployeeEntity>, IEmployeeRepository
{
    public EmployeeRepository(TempoDbContext dbContext) : base(dbContext) 
    {
    }
}
