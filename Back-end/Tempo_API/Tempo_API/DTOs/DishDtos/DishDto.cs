using Tempo_API.DTOs.CategoryDtos;
using Tempo_API.DTOs.DishwareDishDtos;
using Tempo_API.DTOs.TablewareDtos;

namespace Tempo_API.DTOs.DishDtos;

public class DishDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Approx_time { get; set; }
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }

    public CategoryDto Category { get; set; } = new();
    public List<DishwareDishDto> DishwareList { get; set; } = new();
    public List<TablewareDto> TablewareList { get; set; } = new();
}
