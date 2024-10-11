using FluentValidation;
using Tempo_API.DTOs.IngredientDtos;

namespace Tempo_API.Validators;

public class IngredientValidator : AbstractValidator<CreateIngredientDto>
{
    public IngredientValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.In_stock).NotEmpty().NotNull();
    }
}
