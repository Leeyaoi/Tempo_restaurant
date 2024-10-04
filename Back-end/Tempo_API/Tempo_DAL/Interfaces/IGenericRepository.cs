using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tempo_DAL.Entities;

namespace Tempo_DAL.Interfaces;

public interface IGenericRepository<Entity> where Entity : BaseEntity
{
    Task<Entity> Create(Entity entity, CancellationToken cancellationToken);

    Task Delete(Entity entity, CancellationToken cancellationToken);

    Task<Entity> Update(Entity entity, CancellationToken cancellationToken);

    Task<List<Entity>> GetAll(CancellationToken cancellationToken);

    Task<Entity?> GetById(Guid id, CancellationToken cancellationToken);

    Task<List<Entity>> GetByPredicate(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken);
}
