using Tempo_API.DTOs.EmployeeDtos;
using Tempo_API.DTOs.TableDtos;

namespace Tempo_API.DTOs.WaiterDtos;

public class WaiterDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }

    public EmployeeDto? Employee { get; set; }
    public List<TableDto?> Tables { get; set; } = new();
}
