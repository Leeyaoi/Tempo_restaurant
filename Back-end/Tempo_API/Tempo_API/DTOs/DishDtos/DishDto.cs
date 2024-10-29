using Tempo_API.DTOs.CategoryDtos;
using Tempo_API.DTOs.DishwareDishDtos;
using Tempo_API.DTOs.TablewareDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.DishDtos;

public class DishDto : IBaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Approx_time { get; set; }
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public string Photo { get; set; } = string.Empty;

    public CategoryDto? Category { get; set; }
    public List<DishwareDishDto?> DishwareList { get; set; } = new();
    public List<TablewareDto?> TablewareList { get; set; } = new();
}
