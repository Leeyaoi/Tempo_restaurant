using Tempo_API.DTOs.OrderDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.UserDtos;

public class UserDto : IBaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public List<OrderDto?> Orders { get; set; } = new();
}
