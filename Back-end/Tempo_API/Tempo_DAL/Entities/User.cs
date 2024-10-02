namespace Tempo_DAL.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public List<Order> Orders { get; set; } = new();
}
