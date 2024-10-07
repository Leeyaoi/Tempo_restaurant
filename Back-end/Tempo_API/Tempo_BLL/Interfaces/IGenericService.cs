using System.Linq.Expressions;
using Tempo_BLL.Models;

namespace Tempo_BLL.Interfaces;

public interface IGenericService<Model> where Model : BaseModel
{
    Task<Model> Create(Model model, CancellationToken cancellationToken);

    Task Delete(Guid id, CancellationToken cancellationToken);

    Task<Model> Update(Guid id, Model model, CancellationToken cancellationToken);

    Task<List<Model>> GetAll(CancellationToken cancellationToken);

    Task<Model?> GetById(Guid id, CancellationToken cancellationToken);

    Task<List<Model>> GetByPredicate(Expression<Func<Model, bool>> predicate, CancellationToken cancellationToken);
}
