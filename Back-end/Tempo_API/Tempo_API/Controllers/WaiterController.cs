using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.WaiterDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;


namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WaiterController : GenericController<WaiterModel, WaiterDto, CreateWaiterDto>
{
    public WaiterController(IWaiterService service, IMapper mapper) : base(service, mapper)
    {
    }
}
