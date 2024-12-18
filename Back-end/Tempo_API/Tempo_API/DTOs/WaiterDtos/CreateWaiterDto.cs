﻿using Tempo_API.Interfaces;

namespace Tempo_API.DTOs.WaiterDtos;

public class CreateWaiterDto : IBaseDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public Guid EmployeeId { get; set; }
}
