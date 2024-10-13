using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.IngredientDishDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IngredientDishController : GenericController<IngredientDishModel, IngredientDishDto, CreateIngredientDishDto>
{
    public IngredientDishController(IIngredientDishService service, IMapper mapper) : base(service, mapper)
    {
    }
}
