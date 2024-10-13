using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.Interfaces;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenericController<Model, Dto, CreateDto> : ControllerBase where Model : BaseModel where Dto : IBaseDto where CreateDto : IBaseDto
{
    private readonly IGenericService<Model> _service;
    private readonly IMapper _mapper;

    public GenericController(IGenericService<Model> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public Task<PaginatedModel<Model>> GetAll(CancellationToken cancellationToken, int? page, int? limit = 10)
    {
        return _service.GetAll(cancellationToken, page, limit);
    }

    [HttpGet("{id}")]
    public async Task<Dto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<Dto>(model);
    }

    [HttpPost]
    public async Task<Dto> Create([FromBody] CreateDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Model>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<Dto>(result);
    }

    [HttpPut("{id}")]
    public async Task<Dto> Update(Guid id, [FromBody] CreateDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Model>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<Dto>(result);
    }

    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
