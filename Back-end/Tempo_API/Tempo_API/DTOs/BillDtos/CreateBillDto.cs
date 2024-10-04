namespace Tempo_API.DTOs.BillDtos;

public class CreateBillDto
{
    public bool Cash { get; set; }
    public Guid OrderId { get; set; }
}
