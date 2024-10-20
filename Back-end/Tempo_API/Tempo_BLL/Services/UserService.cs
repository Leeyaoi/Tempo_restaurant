using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class UserService : GenericService<UserModel, UserEntity>, IUserService
{
    public UserService(IMapper mapper, IUserRepository repository) : base(mapper, repository)
    {
    }

    public override async Task<UserModel> Create(UserModel model, CancellationToken cancellationToken)
    {
        var search = await _repository.GetByPredicate(x => x.Name == model.Name && x.Phone == model.Phone, cancellationToken);
        if (search.Count == 0)
        {
            return await base.Create(model, cancellationToken);
        }
        return _mapper.Map<UserModel>(search[0]);
    }
}
