using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.TablewareDishDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TablewareDishController : GenericController<TablewareDishModel, TablewareDishDto, CreateTablewareDishDto>
{
    public TablewareDishController(ITablewareDishService service, IMapper mapper) : base(service, mapper)
    {
    }
}
