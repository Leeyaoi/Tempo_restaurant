using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.IngredientDishDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IngredientDishController : ControllerBase
{
    private readonly IIngredientDishService _service;
    private readonly IMapper _mapper;

    public IngredientDishController(IIngredientDishService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    // GET: api/<IngredientDishController>
    [HttpGet]
    public async Task<IEnumerable<IngredientDishDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<IngredientDishDto>>(models);
    }

    // GET api/<IngredientDishController>/5
    [HttpGet("{id}")]
    public async Task<IngredientDishDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<IngredientDishDto>(model);
    }

    // POST api/<IngredientDishController>
    [HttpPost]
    public async Task<IngredientDishDto> Create([FromBody] CreateIngredientDishDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<IngredientDishModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<IngredientDishDto>(result);
    }

    // PUT api/<IngredientDishController>/5
    [HttpPut("{id}")]
    public async Task<IngredientDishDto> Update(Guid id, [FromBody] CreateIngredientDishDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<IngredientDishModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<IngredientDishDto>(result);
    }

    // DELETE api/<TableController>/5
    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
