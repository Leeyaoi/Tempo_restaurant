namespace Tempo_API.DTOs.TableDtos;

public class CreateTableDto
{
    public int Max_people { get; set; }
    public Guid WaiterId { get; set; }
}
