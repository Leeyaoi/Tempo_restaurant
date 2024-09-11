using System;
namespace Tempo_DAL.Entities;

public class Dishware
{
    public Guid Dishware_id {  get; set; }
    public string? Type { get; set; }
    public double In_stock { get; set; }
}
