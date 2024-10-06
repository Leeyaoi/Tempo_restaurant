﻿using Tempo_API.DTOs.CookDtos;
using Tempo_API.DTOs.WaiterDtos;

namespace Tempo_API.DTOs.EmployeeDtos;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public WaiterDto? Waiter { get; set; }
    public CookDto? Cook { get; set; }
}