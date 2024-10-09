using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.EmployeeDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<EmployeeDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<EmployeeDto>>(models);
    }

    [HttpGet("{id}")]
    public async Task<EmployeeDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<EmployeeDto>(model);
    }

    [HttpPost]
    public async Task<EmployeeDto> Create([FromBody] CreateEmployeeDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<EmployeeModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<EmployeeDto>(result);
    }

    [HttpPut("{id}")]
    public async Task<EmployeeDto> Update(Guid id, [FromBody] CreateEmployeeDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<EmployeeModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<EmployeeDto>(result);
    }

    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
