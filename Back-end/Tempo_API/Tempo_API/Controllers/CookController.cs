﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.CookDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CookController : GenericController<CookModel, CookDto, CreateCookDto>
{
    public CookController(ICookService service, IMapper mapper) : base(service, mapper)
    {
    }
}

