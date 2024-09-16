namespace Tempo_DAL.Entities;

public class Cook
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Employee Employee { get; set; } = new();
}
