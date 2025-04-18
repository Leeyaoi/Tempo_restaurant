﻿using AutoMapper;
using System.Linq.Expressions;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class GenericService<Model, Entity> : IGenericService<Model> where Model : BaseModel where Entity : BaseEntity
{
    protected readonly IMapper _mapper;

    protected readonly IGenericRepository<Entity> _repository;

    public GenericService(IMapper mapper, IGenericRepository<Entity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public virtual async Task<Model> Create(Model model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Entity>(model);
        var result = await _repository.Create(entity, cancellationToken);
        return _mapper.Map<Model>(result);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(id, cancellationToken);
        await _repository.Delete(entity, cancellationToken);
    }

    public async Task<Model> Update(Guid id, Model model, CancellationToken cancellationToken)
    {
        model.Id = id;
        var entity = _mapper.Map<Entity>(model);
        var result = await _repository.Update(entity, cancellationToken);
        return _mapper.Map<Model>(result);
    }

    public async Task<PaginatedModel<Model>> GetAll(CancellationToken cancellationToken, int? page, int? limit)
    {
        List<Entity> entities;
        int total, count;
        if (page != null && limit != null)
        {
            entities = await _repository.Paginate((int)limit, (int)page, cancellationToken, out total, out count, null);
        }
        else
        {
            limit = null;
            entities = await _repository.GetAll(cancellationToken, out total, out count);
        }
        return new PaginatedModel<Model>
        {
            Total = total,
            Page = page ?? 1,
            PageCount = count,
            PageSize = limit ?? total,
            Items = _mapper.Map<List<Model>>(entities)
        };
    }

    public async Task<Model?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(id, cancellationToken);
        return _mapper.Map<Model>(entity);
    }

    public async Task<List<Model>> GetByPredicate(Expression<Func<Model, bool>> predicate, CancellationToken cancellationToken)
    {
        var entityPred = _mapper.Map<Expression<Func<Entity, bool>>>(predicate);
        var entity = await _repository.GetByPredicate(entityPred, cancellationToken);
        return _mapper.Map<List<Model>>(entity);
    }
}
