namespace Tempo_DAL.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
