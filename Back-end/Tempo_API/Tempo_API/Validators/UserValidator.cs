using FluentValidation;
using Tempo_API.DTOs.UserDtos;

namespace Tempo_API.Validators;

public class UserValidator : AbstractValidator<CreateUserDto>
{
    public UserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.Phone).NotEmpty().NotNull();
    }
}
