using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.EmployeeDtos;

public class CreateEmployeeDto : IBaseDto
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
