using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class CookRepository : GenericRepository<CookEntity>, ICookRepository
{
    public CookRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }

    public override Task<List<CookEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new CookEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       Name = e.Name,
                       Surname = e.Surname,
                       EmployeeId = e.EmployeeId,
                       CategoryId = e.CategoryId,
                       Employee = e.Employee,
                       Category = e.Category,
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<CookEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new CookEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                Name = e.Name,
                                Surname = e.Surname,
                                EmployeeId = e.EmployeeId,
                                CategoryId = e.CategoryId,
                                Employee = e.Employee,
                                Category = e.Category,
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}
