using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.TablewareDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TablewareController : ControllerBase
{
    private readonly ITablewareService _service;
    private readonly IMapper _mapper;

    public TablewareController(ITablewareService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    // GET: api/<TablewareController>
    [HttpGet]
    public async Task<IEnumerable<TablewareDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<TablewareDto>>(models);
    }

    // GET api/<TablewareController>/5
    [HttpGet("{id}")]
    public async Task<TablewareDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<TablewareDto>(model);
    }

    // POST api/<TablewareController>
    [HttpPost]
    public async Task<TablewareDto> Create([FromBody] CreateTablewareDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TablewareModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<TablewareDto>(result);
    }

    // PUT api/<TablewareController>/5
    [HttpPut("{id}")]
    public async Task<TablewareDto> Update(Guid id, [FromBody] CreateTablewareDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TablewareModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<TablewareDto>(result);
    }

    // DELETE api/<TablewareController>/5
    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
