namespace Tempo_DAL.Entities;

public class CooksCategory
{
    public Cooks Cook { get; set; } = new();
    public Category Category { get; set; } = new();
}
