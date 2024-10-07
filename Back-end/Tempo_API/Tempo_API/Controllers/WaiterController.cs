using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.WaiterDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;


namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WaiterController : ControllerBase
{
    private readonly IWaiterService _service;
    private readonly IMapper _mapper;

    public WaiterController(IWaiterService service, IMapper mapper)
    {
        _mapper = mapper;
        _service = service;
    }

    // GET: api/<WaiterController>
    [HttpGet]
    public async Task<IEnumerable<WaiterDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<WaiterDto>>(models);
    }

    // GET api/<WaiterController>/5
    [HttpGet("{id}")]
    public async Task<WaiterDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<WaiterDto>(model);
    }

    // POST api/<WaiterController>
    [HttpPost]
    public async Task<WaiterDto> Create([FromBody] CreateWaiterDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<WaiterModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<WaiterDto>(result);
    }

    // PUT api/<WaiterController>/5
    [HttpPut("{id}")]
    public async Task<WaiterDto> Put(Guid id, [FromBody] CreateWaiterDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<WaiterModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<WaiterDto>(result);
    }

    // DELETE api/<WaiterController>/5
    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
