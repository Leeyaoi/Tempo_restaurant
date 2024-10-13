using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.TablewareDishDtos;

public class CreateTablewareDishDto : IBaseDto
{
    public Guid TablewareId { get; set; }
    public Guid DishId { get; set; }
}
