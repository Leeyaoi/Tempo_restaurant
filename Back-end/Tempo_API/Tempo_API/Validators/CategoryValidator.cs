using FluentValidation;
using Tempo_API.DTOs.CategoryDtos;

namespace Tempo_API.Validators;

public class CategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
