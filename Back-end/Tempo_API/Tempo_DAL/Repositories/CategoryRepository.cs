using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
{
    public CategoryRepository(TempoDbContext dbcontext) : base(dbcontext)
    {
    }

    public override Task<List<CategoryEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new CategoryEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       Name = e.Name,
                       Cooks = e.Cooks,
                       Drinks = e.Drinks,
                       Dishes = e.Dishes,
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<CategoryEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new CategoryEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                Name = e.Name,
                                Cooks = e.Cooks,
                                Drinks = e.Drinks,
                                Dishes = e.Dishes,
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}
