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
}
