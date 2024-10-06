using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class IngredientService : GenericService<IngredientModel, IngredientEntity>, IIngredientService
{
    public IngredientService(IMapper mapper, IIngredientRepository repository) : base(mapper, repository)
    {
    }
}
