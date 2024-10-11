using FluentValidation;
using Tempo_API.DTOs.DishwareDtos;

namespace Tempo_API.Validators;

public class DishwareValidator : AbstractValidator<CreateDishwareDto>
{
    public DishwareValidator()
    {
        RuleFor(x => x.In_stock).NotEmpty().NotNull();
        RuleFor(x => x.Type).NotEmpty().NotNull();
    }
}
