using Tempo_API.DTOs.OrderDtos;

namespace Tempo_API.DTOs.UserDtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public List<OrderDto?> Orders { get; set; } = new();
}
