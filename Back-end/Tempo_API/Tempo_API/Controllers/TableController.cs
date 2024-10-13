using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.TableDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TableController : GenericController<TableModel, TableDto, CreateTableDto>
{
    public TableController(ITableService service, IMapper mapper) : base(service, mapper)
    {
    }
}
