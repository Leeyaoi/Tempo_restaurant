using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.IngredientDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IngredientController : GenericController<IngredientModel, IngredientDto, CreateIngredientDto>
{
    public IngredientController(IIngredientService service, IMapper mapper) : base(service, mapper)
    {
    }
}
