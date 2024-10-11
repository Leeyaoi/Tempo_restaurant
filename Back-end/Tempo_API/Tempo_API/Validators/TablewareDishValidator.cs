using FluentValidation;
using Tempo_API.DTOs.TablewareDishDtos;

namespace Tempo_API.Validators;

public class TablewareDishValidator : AbstractValidator<CreateTablewareDishDto>
{
    public TablewareDishValidator()
    {
        RuleFor(x => x.DishId).NotEmpty().NotNull();
        RuleFor(x => x.TablewareId).NotEmpty().NotNull();
    }
}
