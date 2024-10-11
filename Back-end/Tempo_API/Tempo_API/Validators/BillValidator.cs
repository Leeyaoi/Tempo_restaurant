using FluentValidation;
using Tempo_API.DTOs.BillDtos;

namespace Tempo_API.Validators;

public class BillValidator : AbstractValidator<CreateBillDto>
{
    public BillValidator()
    {
        RuleFor(x => x.Cash).NotNull().NotEmpty();
        RuleFor(x => x.OrderId).NotNull().NotEmpty();
    }
}
