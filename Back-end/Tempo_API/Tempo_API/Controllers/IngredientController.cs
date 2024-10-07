using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.IngredientDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _service;
    private readonly IMapper _mapper;

    public IngredientController(IIngredientService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    // GET: api/<IngredientController>
    [HttpGet]
    public async Task<IEnumerable<IngredientDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<IngredientDto>>(models);
    }

    // GET api/<IngredientController>/5
    [HttpGet("{id}")]
    public async Task<IngredientDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<IngredientDto>(model);
    }

    // POST api/<IngredientController>
    [HttpPost]
    public async Task<IngredientDto> Create([FromBody] CreateIngredientDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<IngredientModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<IngredientDto>(result);
    }

    // PUT api/<IngredientController>/5
    [HttpPut("{id}")]
    public async Task<IngredientDto> Update(Guid id, [FromBody] CreateIngredientDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<IngredientModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<IngredientDto>(result);
    }

    // DELETE api/<TableController>/5
    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
