using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class BillService : GenericService<BillModel, BillEntity>, IBillService
{
    public BillService(IMapper mapper, IBillRepository repository) : base(mapper, repository)
    {
    }
}
