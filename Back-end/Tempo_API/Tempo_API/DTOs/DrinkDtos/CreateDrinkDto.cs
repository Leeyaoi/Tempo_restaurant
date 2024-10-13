using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DrinkDtos;

public class CreateDrinkDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
}
