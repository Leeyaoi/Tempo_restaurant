﻿using System.Linq.Expressions;
using Tempo_DAL.Entities;

namespace Tempo_DAL.Interfaces;

public interface IGenericRepository<Entity> where Entity : BaseEntity
{
    Task<Entity> Create(Entity entity, CancellationToken cancellationToken);

    Task Delete(Entity entity, CancellationToken cancellationToken);

    Task<Entity> Update(Entity entity, CancellationToken cancellationToken);

    Task<List<Entity>> GetAll(CancellationToken cancellationToken, out int total, out int count);

    Task<Entity> GetById(Guid id, CancellationToken cancellationToken);

    Task<List<Entity>> GetByPredicate(Expression<Func<Entity, bool>> predicate, CancellationToken cancellationToken);

    Task<List<Entity>> Paginate(int limit, int page, CancellationToken cancellationToken, out int total, out int count, Expression<Func<Entity, bool>>? predicate);
}
