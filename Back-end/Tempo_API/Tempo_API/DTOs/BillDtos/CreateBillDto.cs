using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.BillDtos;

public class CreateBillDto : IBaseDto
{
    public bool Cash { get; set; }
    public Guid OrderId { get; set; }
}
