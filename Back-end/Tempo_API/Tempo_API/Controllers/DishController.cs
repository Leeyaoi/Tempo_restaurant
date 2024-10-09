using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.DishDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DishController : ControllerBase
{
    private readonly IDishService _service;
    private readonly IMapper _mapper;

    public DishController(IDishService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DishDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<DishDto>>(models);
    }

    [HttpGet("{id}")]
    public async Task<DishDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<DishDto>(model);
    }

    [HttpPost]
    public async Task<DishDto> Create([FromBody] CreateDishDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<DishModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<DishDto>(result);
    }

    [HttpPut("{id}")]
    public async Task<DishDto> Update(Guid id, [FromBody] CreateDishDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<DishModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<DishDto>(result);
    }

    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}

