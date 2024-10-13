using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.EmployeeDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : GenericController<EmployeeModel, EmployeeDto, CreateEmployeeDto>
{
    public EmployeeController(IEmployeeService service, IMapper mapper) : base(service, mapper)
    {
    }
}
