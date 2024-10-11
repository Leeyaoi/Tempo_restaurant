using FluentValidation;
using Tempo_API.DTOs.CookDtos;

namespace Tempo_API.Validators;

public class CookValidator : AbstractValidator<CreateCookDto>
{
    public CookValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.Surname).NotEmpty().NotNull();
        RuleFor(x => x.EmployeeId).NotEmpty().NotNull();
        RuleFor(x => x.CategoryId).NotEmpty().NotNull();
    }
}
