using FluentValidation;
using Tempo_API.DTOs.OrderDtos;

namespace Tempo_API.Validators;

public class OrderValidator : AbstractValidator<CreateOrderDto>
{
    public OrderValidator()
    {
        RuleFor(x => x.People_num).NotEmpty().NotNull();
        RuleFor(x => x.TableId).NotEmpty().NotNull();
        RuleFor(x => x.DishesId).NotEmpty().NotNull();
    }
}
