using Tempo_API.DTOs.DishDtos;
using Tempo_API.DTOs.TablewareDtos;
using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.TablewareDishDtos;

public class TablewareDishDto : IBaseDto
{
    public Guid TablewareId { get; set; }
    public Guid DishId { get; set; }

    public TablewareDto? Tableware { get; set; }
    public DishDto? Dish { get; set; }
}
