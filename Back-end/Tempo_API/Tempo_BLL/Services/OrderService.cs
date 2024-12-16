using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class OrderService : GenericService<OrderModel, OrderEntity>, IOrderService
{
    private readonly IDishOrderRepository _DishRepository;
    private readonly IDrinkOrderRepository _DrinkRepository;

    public OrderService(IMapper mapper, IOrderRepository repository,
        IDishOrderRepository dishRepository, IDrinkOrderRepository drinkRepository) : base(mapper, repository)
    {
        _DishRepository = dishRepository;
        _DrinkRepository = drinkRepository;
    }

    public override async Task<OrderModel> Create(OrderModel model, CancellationToken cancellationToken)
    {
        var result = await base.Create(model, cancellationToken);
        foreach (var drinkId in model.DrinksId)
        {
            await _DrinkRepository.Create(new DrinkOrderEntity { DrinkId = drinkId, OrderId = result.Id }, cancellationToken);
            result.DrinksId.Add(drinkId);
        }
        foreach (var dishId in model.DishesId)
        {
            await _DishRepository.Create(new DishOrderEntity { DishId = dishId, OrderId = result.Id }, cancellationToken);
            result.DishesId.Add(dishId);
        }
        return result;
    }
}
