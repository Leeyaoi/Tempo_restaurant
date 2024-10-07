using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.UserDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly IMapper _mapper;

    public UserController(IUserService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    // GET: api/<UserController>
    [HttpGet]
    public async Task<IEnumerable<UserDto>> GetAll(CancellationToken cancellationToken)
    {
        var models = await _service.GetAll(cancellationToken);
        return _mapper.Map<IEnumerable<UserDto>>(models);
    }

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public async Task<UserDto> GetById(Guid id, CancellationToken cancellationToken)
    {
        var model = await _service.GetById(id, cancellationToken);
        return _mapper.Map<UserDto>(model);
    }

    // POST api/<UserController>
    [HttpPost]
    public async Task<UserDto> Create([FromBody] CreateUserDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<UserModel>(dto);
        var result = await _service.Create(model, cancellationToken);
        return _mapper.Map<UserDto>(result);
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public async Task<UserDto> Update(Guid id, [FromBody] CreateUserDto dto, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<UserModel>(dto);
        var result = await _service.Update(id, model, cancellationToken);
        return _mapper.Map<UserDto>(result);
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        return _service.Delete(id, cancellationToken);
    }
}
