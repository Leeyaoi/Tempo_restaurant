using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.TablewareDishDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TablewareDishController : ControllerBase
{
    private readonly ITablewareDishService _service;
    private readonly IMapper _mapper;

    public TablewareDishController(ITablewareDishService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    // GET: api/<TablewareDishController>
    [HttpGet]
    public async Task<IEnumerable<TablewareDishDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<TablewareDishDto>>(models);
    }

    // GET api/<TablewareDishController>/5
    [HttpGet("{id}")]
    public async Task<TablewareDishDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<TablewareDishDto>(model);
    }

    // POST api/<TablewareController>
    [HttpPost]
    public async Task<TablewareDishDto> Create([FromBody] CreateTablewareDishDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TablewareDishModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<TablewareDishDto>(result);
    }

    // PUT api/<TablewareController>/5
    [HttpPut("{id}")]
    public async Task<TablewareDishDto> Update(Guid id, [FromBody] CreateTablewareDishDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TablewareDishModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<TablewareDishDto>(result);
    }

    // DELETE api/<TablewareController>/5
    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
