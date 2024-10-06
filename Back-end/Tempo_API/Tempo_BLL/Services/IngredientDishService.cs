using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class IngredientDishService : GenericService<IngredientDishModel, IngredientDishEntity>, IIngredientDishService
{
    public IngredientDishService(IMapper mapper, IIngredientDishRepository repository) : base(mapper, repository)
    {
    }
}
