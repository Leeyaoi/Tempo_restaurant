using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.DishwareDishDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DishwareDishController : ControllerBase
{
    private readonly IDishwareDishService _service;
    private readonly IMapper _mapper;

    public DishwareDishController(IDishwareDishService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DishwareDishDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<DishwareDishDto>>(models);
    }

    [HttpGet("{id}")]
    public async Task<DishwareDishDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<DishwareDishDto>(model);
    }

    [HttpPost]
    public async Task<DishwareDishDto> Create([FromBody] CreateDishwareDishDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<DishwareDishModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<DishwareDishDto>(result);
    }

    [HttpPut("{id}")]
    public async Task<DishwareDishDto> Update(Guid id, [FromBody] CreateDishwareDishDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<DishwareDishModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<DishwareDishDto>(result);
    }

    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
