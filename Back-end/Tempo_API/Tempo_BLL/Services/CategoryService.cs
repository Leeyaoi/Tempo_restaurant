using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class CategoryService : GenericService<CategoryModel, CategoryEntity>, ICategoryService
{
    public CategoryService(IMapper mapper, ICategoryRepository repository) : base(mapper, repository) 
    {
    }
}
