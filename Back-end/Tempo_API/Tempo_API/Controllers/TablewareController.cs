using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.TablewareDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TablewareController : GenericController<TablewareModel, TablewareDto, CreateTablewareDto>
{
    public TablewareController(ITablewareService service, IMapper mapper) : base(service, mapper)
    {
    }
}
