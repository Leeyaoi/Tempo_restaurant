using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.DishwareDishDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DishwareDishController : GenericController<DishwareDishModel, DishwareDishDto, CreateDishwareDishDto>
{
    public DishwareDishController(IDishwareDishService service, IMapper mapper) : base(service, mapper)
    {
    }
}
