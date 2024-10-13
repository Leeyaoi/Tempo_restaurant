using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.CookDtos;

public class CreateCookDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
    public Guid CategoryId { get; set; }
}
