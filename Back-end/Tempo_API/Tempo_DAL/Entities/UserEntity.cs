namespace Tempo_DAL.Entities;

public class UserEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public List<OrderEntity?> Orders { get; set; } = new();
}
