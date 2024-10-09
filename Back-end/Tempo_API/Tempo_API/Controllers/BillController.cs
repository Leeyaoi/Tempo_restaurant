using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.BillDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillController : ControllerBase
{
    private readonly IBillService _service;
    private readonly IMapper _mapper;

    public BillController(IBillService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<BillDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<BillDto>>(models);
    }

    [HttpGet("{id}")]
    public async Task<BillDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<BillDto>(model);
    }

    [HttpPost]
    public async Task<BillDto> Create([FromBody] CreateBillDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<BillModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<BillDto>(result);
    }

    [HttpPut("{id}")]
    public async Task<BillDto> Update(Guid id, [FromBody] CreateBillDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<BillModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<BillDto>(result);
    }

    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}

