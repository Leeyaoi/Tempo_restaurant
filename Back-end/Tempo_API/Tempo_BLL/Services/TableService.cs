using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class TableService : GenericService<TableModel, TableEntity>, ITableService
{
    public TableService(IMapper mapper, ITableRepository repository) : base(mapper, repository)
    {
    }
}
