using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.DishwareDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DishwareController : GenericController<DishwareModel, DishwareDto, CreateDishwareDto>
{
    public DishwareController(IDishwareService service, IMapper mapper) : base(service, mapper)
    {
    }
}
