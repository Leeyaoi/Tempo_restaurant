namespace Tempo_API.DTOs.DrinkDtos;

public class CreateDrinkDto
{
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
}
