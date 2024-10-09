using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.CategoryDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<CategoryDto>>(models);
    }

    [HttpGet("{id}")]
    public async Task<CategoryDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<CategoryDto>(model);
    }

    [HttpPost]
    public async Task<CategoryDto> Create([FromBody] CreateCategoryDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<CategoryModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<CategoryDto>(result);
    }

    [HttpPut("{id}")]
    public async Task<CategoryDto> Update(Guid id, [FromBody] CreateCategoryDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<CategoryModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<CategoryDto>(result);
    }

    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}

