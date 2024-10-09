using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.DrinkDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DrinkController : ControllerBase
{
    private readonly IDrinkService _service;
    private readonly IMapper _mapper;

    public DrinkController(IDrinkService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DrinkDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<DrinkDto>>(models);
    }

    [HttpGet("{id}")]
    public async Task<DrinkDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<DrinkDto>(model);
    }

    [HttpPost]
    public async Task<DrinkDto> Create([FromBody] CreateDrinkDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<DrinkModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<DrinkDto>(result);
    }

    [HttpPut("{id}")]
    public async Task<DrinkDto> Update(Guid id, [FromBody] CreateDrinkDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<DrinkModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<DrinkDto>(result);
    }

    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
