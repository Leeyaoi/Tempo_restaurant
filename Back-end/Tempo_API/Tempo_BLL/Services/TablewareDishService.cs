using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class TablewareDishService : GenericService<TablewareDishModel, TablewareDishEntity>, ITablewareDishService
{
    public TablewareDishService(IMapper mapper, ITablewareDishRepository repository) : base(mapper, repository)
    {
    }
}
