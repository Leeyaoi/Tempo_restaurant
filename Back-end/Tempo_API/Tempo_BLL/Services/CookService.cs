﻿using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class CookService : GenericService<CookModel, CookEntity>, ICookService
{
    public CookService(IMapper mapper, ICookRepository repository) : base(mapper, repository) 
    {
    }
}