using FluentValidation;
using Tempo_API.DTOs.TableDtos;

namespace Tempo_API.Validators;

public class TableValidator : AbstractValidator<CreateTableDto>
{
    public TableValidator()
    {
        RuleFor(x => x.Max_people).NotEmpty().NotNull();
        RuleFor(x => x.WaiterId).NotEmpty().NotNull();
    }
}
