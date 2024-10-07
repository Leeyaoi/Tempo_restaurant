using AutoMapper;
using System.Linq.Expressions;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class GenericService<Model, Entity> : IGenericService<Model> where Model : BaseModel where Entity : BaseEntity
{
    private readonly IMapper _mapper;

    private readonly IGenericRepository<Entity> _repository;

    public GenericService(IMapper mapper, IGenericRepository<Entity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Model> Create(Model model, CancellationToken cancellationToken)
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

    public async Task<List<Model>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAll(cancellationToken);
        return _mapper.Map<List<Model>>(entities);
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
