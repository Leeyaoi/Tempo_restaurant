using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class DishwareDishService : GenericService<DishwareDishModel, DishwareDishEntity>, IDishwareDishService
{
    public DishwareDishService(IMapper mapper, IDishwareDishRepository repository) : base(mapper, repository) 
    {
    }
}
