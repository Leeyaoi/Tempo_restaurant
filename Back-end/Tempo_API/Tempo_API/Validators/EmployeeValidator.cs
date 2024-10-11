using FluentValidation;
using Tempo_API.DTOs.EmployeeDtos;

namespace Tempo_API.Validators;

public class EmployeeValidator : AbstractValidator<CreateEmployeeDto>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.Password).NotEmpty().NotNull();
        RuleFor(x => x.Login).NotEmpty().NotNull();
    }
}