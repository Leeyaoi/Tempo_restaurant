using FluentValidation;
using Tempo_API.DTOs.DishwareDishDtos;

namespace Tempo_API.Validators;

public class DishwareDishValidator : AbstractValidator<CreateDishwareDishDto>
{
    public DishwareDishValidator()
    {
        RuleFor(x => x.DishwareId).NotEmpty().NotNull();
        RuleFor(x => x.DishId).NotEmpty().NotNull();
    }
}
