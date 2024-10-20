using Tempo_BLL.Models;

namespace Tempo_BLL.Interfaces;

public interface IUserService : IGenericService<UserModel>
{
    Task<UserModel> Create(UserModel model, CancellationToken cancellationToken);
}
