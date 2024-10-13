using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tempo_API.DTOs.CategoryDtos;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;

namespace Tempo_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : GenericController<CategoryModel, CategoryDto, CreateCategoryDto>
{
    public CategoryController(ICategoryService service, IMapper mapper) : base(service, mapper)
    {
    }
}

