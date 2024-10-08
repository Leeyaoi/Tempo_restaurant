using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class DishService : GenericService<DishModel, DishEntity>, IDishService
{
    public DishService(IMapper mapper, IDishRepository repository) : base(mapper, repository) 
    {
    }
}
