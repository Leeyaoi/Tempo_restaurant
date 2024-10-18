using Microsoft.EntityFrameworkCore;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;
using Tempo_Shared.Exeption;

namespace Tempo_DAL.Repositories;

public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
    public UserRepository(TempoDbContext dbсontext) : base(dbсontext)
    {
    }

    public override Task<List<UserEntity>> GetAll(CancellationToken cancellationToken, out int total, out int count)
    {
        var data = from e in dbSet
                   select new UserEntity()
                   {
                       Id = e.Id,
                       CreatedAt = e.CreatedAt,
                       UpdatedAt = e.UpdatedAt,
                       Name = e.Name,
                       Phone = e.Phone,
                       Orders = e.Orders,
                   };

        total = data.Count();
        count = 1;
        return data.ToListAsync(cancellationToken);
    }

    public override async Task<UserEntity> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await (from e in dbSet
                            where e.Id == id
                            select new UserEntity()
                            {
                                Id = e.Id,
                                CreatedAt = e.CreatedAt,
                                UpdatedAt = e.UpdatedAt,
                                Name = e.Name,
                                Phone = e.Phone,
                                Orders = e.Orders,
                            }).FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundException();
        }
        return result;
    }
}
