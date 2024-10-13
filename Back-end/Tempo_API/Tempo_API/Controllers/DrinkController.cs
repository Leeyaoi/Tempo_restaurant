using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.DrinkDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrinkController : GenericController<DrinkModel, DrinkDto, CreateDrinkDto>
{
    public DrinkController(IDrinkService service, IMapper mapper) : base(service, mapper)
    {
    }
}
