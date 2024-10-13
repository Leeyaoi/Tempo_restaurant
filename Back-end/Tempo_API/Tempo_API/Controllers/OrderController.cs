using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.OrderDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : GenericController<OrderModel, OrderDto, CreateOrderDto>
{
    public OrderController(IOrderService service, IMapper mapper) : base(service, mapper)
    {
    }
}
