using Tempo_API.DTOs.CategoryDtos;
using Tempo_API.DTOs.EmployeeDtos;

namespace Tempo_API.DTOs.CookDtos;

public class CookDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
    public Guid CategoryId { get; set; }

    public EmployeeDto Employee { get; set; } = new();
    public CategoryDto Category { get; set; } = new();
}
