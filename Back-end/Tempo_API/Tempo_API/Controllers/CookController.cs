using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.CookDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CookController : ControllerBase
{
    private readonly ICookService _service;
    private readonly IMapper _mapper;

    public CookController(ICookService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CookDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<CookDto>>(models);
    }

    [HttpGet("{id}")]
    public async Task<CookDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<CookDto>(model);
    }

    [HttpPost]
    public async Task<CookDto> Create([FromBody] CreateCookDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<CookModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<CookDto>(result);
    }

    [HttpPut("{id}")]
    public async Task<CookDto> Update(Guid id, [FromBody] CreateCookDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<CookModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<CookDto>(result);
    }

    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}

