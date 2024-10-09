using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class DishwareService : GenericService<DishwareModel, DishwareEntity>, IDishwareService
{
    public DishwareService(IMapper mapper, IDishwareRepository repository) : base(mapper, repository) 
    {
    }
}
