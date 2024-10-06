using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class WaiterService : GenericService<WaiterModel, WaiterEntity>, IWaiterService
{
    public WaiterService(IMapper mapper, IWaiterRepository repository) : base(mapper, repository)
    {
    }
}
