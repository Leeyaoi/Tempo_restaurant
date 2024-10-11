using FluentValidation;
using Tempo_API.DTOs.TablewareDtos;

namespace Tempo_API.Validators;

public class TablewareValidation : AbstractValidator<CreateTablewareDto>
{
    public TablewareValidation()
    {
        RuleFor(x => x.In_stock).NotNull().NotEmpty();
        RuleFor(x => x.Type).NotEmpty().NotNull();
    }
}
