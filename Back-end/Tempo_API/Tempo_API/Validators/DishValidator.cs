using FluentValidation;
using Tempo_API.DTOs.DishDtos;

namespace Tempo_API.Validators;

public class DishValidator : AbstractValidator<CreateDishDto>
{
    public DishValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.Approx_time).NotEmpty().NotNull();
        RuleFor(x => x.Price).NotEmpty().NotNull();
        RuleFor(x => x.CategoryId).NotEmpty().NotNull();
    }
}
