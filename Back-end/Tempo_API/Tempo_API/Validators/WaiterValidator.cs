using FluentValidation;
using Tempo_API.DTOs.WaiterDtos;

namespace Tempo_API.Validators;

public class WaiterValidator : AbstractValidator<CreateWaiterDto>
{
    public WaiterValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.Surname).NotEmpty().NotNull();
        RuleFor(x => x.EmployeeId).NotEmpty().NotNull();
    }
}
