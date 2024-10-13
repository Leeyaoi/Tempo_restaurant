using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.TableDtos;

public class CreateTableDto : IBaseDto
{
    public int Max_people { get; set; }
    public Guid WaiterId { get; set; }
}
