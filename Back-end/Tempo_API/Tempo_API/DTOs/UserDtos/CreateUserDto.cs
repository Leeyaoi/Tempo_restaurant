using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.UserDtos;

public class CreateUserDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
