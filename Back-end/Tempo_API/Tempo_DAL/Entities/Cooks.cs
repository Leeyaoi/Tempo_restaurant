namespace Tempo_DAL.Entities;

public class Cooks
{
    public Guid Cook_id { get; set; }
    public string? Cook_name { get; set; }
    public string? Cook_SurName { get; set; }
    public Guid Employees_id { get; set; }

}
