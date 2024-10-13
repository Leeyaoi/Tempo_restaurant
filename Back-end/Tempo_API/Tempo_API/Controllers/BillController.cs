using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.BillDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillController : GenericController<BillModel, BillDto, CreateBillDto>
{
    public BillController(IBillService service, IMapper mapper) : base(service, mapper)
    {    }
}

