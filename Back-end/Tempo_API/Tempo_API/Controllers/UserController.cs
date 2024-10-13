using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.UserDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : GenericController<UserModel, UserDto, CreateUserDto>
{
    public UserController(IUserService service, IMapper mapper) : base(service, mapper)
    {
    }
}
