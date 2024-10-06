using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_DAL.Repositories;

public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
    public UserRepository(TempoDbContext dbContext) : base(dbContext)
    {
    }
}
