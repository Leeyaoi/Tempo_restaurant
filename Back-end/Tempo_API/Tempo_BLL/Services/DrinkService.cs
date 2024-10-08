using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class DrinkService : GenericService<DrinkModel, DrinkEntity>, IDrinkService
{
    public DrinkService(IMapper mapper, IDrinkRepository repository) : base(mapper, repository) 
    {
    }
}
