using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.DishDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DishController : GenericController<DishModel, DishDto, CreateDishDto>
{
    public DishController(IDishService service, IMapper mapper) : base(service, mapper)
    {
    }

    [HttpGet("dish")]
    public async Task<List<DishDto>> GetByQuery(CancellationToken cancellationToken, string query)
    {
        var models = await _service.GetByPredicate(x => x.Name.ToLower().Contains(query.ToLower()), cancellationToken);
        return _mapper.Map<List<DishDto>>(models);
    }
}

