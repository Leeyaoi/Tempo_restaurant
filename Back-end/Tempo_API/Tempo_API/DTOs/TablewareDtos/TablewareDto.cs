using Tempo_API.DTOs.TablewareDishDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.TablewareDtos;

public class TablewareDto : IBaseDto
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public double In_stock { get; set; }

    public List<TablewareDishDto?> Dishes { get; set; } = new();
}
