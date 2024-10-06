using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class OrderService : GenericService<OrderModel, OrderEntity>, IOrderService
{
    public OrderService(IMapper mapper, IOrderRepository repository) : base(mapper, repository)
    {
    }
}
