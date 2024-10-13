using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.TablewareDtos;

public class CreateTablewareDto : IBaseDto
{
    public string Type { get; set; } = string.Empty;
    public double In_stock { get; set; }
}
