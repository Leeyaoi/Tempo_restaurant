using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.TableDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TableController : ControllerBase
{
    private readonly ITableService _service;
    private readonly IMapper _mapper;

    public TableController(ITableService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    // GET: api/<TableController>
    [HttpGet]
    public async Task<IEnumerable<TableDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<TableDto>>(models);
    }

    // GET api/<TableController>/5
    [HttpGet("{id}")]
    public async Task<TableDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<TableDto>(model);
    }

    // POST api/<TableController>
    [HttpPost]
    public async Task<TableDto> Create([FromBody] CreateTableDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TableModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<TableDto>(result);
    }

    // PUT api/<TableController>/5
    [HttpPut("{id}")]
    public async Task<TableDto> Update(Guid id, [FromBody] CreateTableDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TableModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<TableDto>(result);
    }

    // DELETE api/<TableController>/5
    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
