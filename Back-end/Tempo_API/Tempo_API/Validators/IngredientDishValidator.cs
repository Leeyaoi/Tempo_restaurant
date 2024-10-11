using FluentValidation;
using Tempo_API.DTOs.IngredientDishDtos;

namespace Tempo_API.Validators;

public class IngredientDishValidator : AbstractValidator<CreateIngredientDishDto>
{
    public IngredientDishValidator()
    {
        RuleFor(x => x.DishId).NotEmpty().NotNull();
        RuleFor(x => x.IngredientId).NotEmpty().NotNull();
    }
}
