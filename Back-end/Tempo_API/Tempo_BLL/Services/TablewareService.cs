using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class TablewareService : GenericService<TablewareModel, TablewareEntity>, ITablewareService
{
    public TablewareService(IMapper mapper, ITablewareRepository repository) : base(mapper, repository)
    {
    }
}
