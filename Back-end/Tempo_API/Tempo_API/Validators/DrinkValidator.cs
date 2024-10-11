using FluentValidation;
using Tempo_API.DTOs.DrinkDtos;

namespace Tempo_API.Validators;

public class DrinkValidator : AbstractValidator<CreateDrinkDto>
{
    public DrinkValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.CategoryId).NotEmpty().NotNull();
    }
}
