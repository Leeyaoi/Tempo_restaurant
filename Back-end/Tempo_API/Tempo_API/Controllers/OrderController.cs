using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.OrderDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;
    private readonly IMapper _mapper;

    public OrderController(IOrderService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    // GET: api/<OrderController>
    [HttpGet]
    public async Task<IEnumerable<OrderDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<OrderDto>>(models);
    }

    // GET api/<OrderController>/5
    [HttpGet("{id}")]
    public async Task<OrderDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<OrderDto>(model);
    }

    // POST api/<OrderController>
    [HttpPost]
    public async Task<OrderDto> Create([FromBody] CreateOrderDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<OrderModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<OrderDto>(result);
    }

    // PUT api/<OrderController>/5
    [HttpPut("{id}")]
    public async Task<OrderDto> Update(Guid id, [FromBody] CreateOrderDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<OrderModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<OrderDto>(result);
    }

    // DELETE api/<TableController>/5
    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
